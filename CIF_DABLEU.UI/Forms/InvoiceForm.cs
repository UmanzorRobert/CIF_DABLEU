using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.Entities.Models;
using System.ComponentModel; // Necesario para BindingList
using System.Data;
using System.Globalization; // Necesario para formato de moneda

namespace CIF_DABLEU.UI.Forms
{
    public partial class InvoiceForm : Form
    {
        // Servicios inyectados por DI
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IInvoiceService _invoiceService;

        // "Carrito de compras" local usando una clase anidada para mejor visualización
        private class CartItemViewModel
        {
            public int ProductId { get; set; }
            public string Producto { get; set; } = string.Empty;
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal SubTotal => Cantidad * PrecioUnitario;
        }

        // Usamos BindingList porque notifica automáticamente al DataGridView cuando hay cambios.
        private readonly BindingList<CartItemViewModel> _shoppingCart;

        public InvoiceForm(IProductService productService, ICustomerService customerService, IInvoiceService invoiceService)
        {
            InitializeComponent();
            _productService = productService;
            _customerService = customerService;
            _invoiceService = invoiceService;

            _shoppingCart = new BindingList<CartItemViewModel>();
        }

        private async void InvoiceForm_Load(object sender, EventArgs e)
        {
            // Enlazar el "carrito" al DataGridView de detalles
            dgvInvoiceDetails.DataSource = _shoppingCart;

            // Cargar los datos iniciales
            await LoadCustomersAsync();
            await LoadProductsAsync();

            // Configurar columnas para que se vean bien
            ConfigureGrids();
        }

        private async Task LoadCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            cmbCustomers.DataSource = customers.ToList();
            cmbCustomers.DisplayMember = "Name"; // La propiedad del objeto Customer que se mostrará
            cmbCustomers.ValueMember = "Id";     // La propiedad del objeto Customer que será el valor
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            dgvProducts.DataSource = products.ToList();
        }

        private void ConfigureGrids()
        {
            // Configurar grid de productos disponibles
            if (dgvProducts.Columns["Id"] != null) dgvProducts.Columns["Id"].Visible = false;
            if (dgvProducts.Columns["Description"] != null) dgvProducts.Columns["Description"].Visible = false;
            if (dgvProducts.Columns["Name"] != null) dgvProducts.Columns["Name"].HeaderText = "Producto";
            if (dgvProducts.Columns["Price"] != null)
            {
                dgvProducts.Columns["Price"].HeaderText = "Precio";
                dgvProducts.Columns["Price"].DefaultCellStyle.Format = "C2"; // Formato Moneda
            }
            if (dgvProducts.Columns["Stock"] != null) dgvProducts.Columns["Stock"].HeaderText = "Stock";

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar grid del detalle de la factura
            if (dgvInvoiceDetails.Columns["ProductId"] != null) dgvInvoiceDetails.Columns["ProductId"].Visible = false;
            if (dgvInvoiceDetails.Columns["PrecioUnitario"] != null) dgvInvoiceDetails.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            if (dgvInvoiceDetails.Columns["SubTotal"] != null) dgvInvoiceDetails.Columns["SubTotal"].DefaultCellStyle.Format = "C2";

            dgvInvoiceDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // 1. Validar que hay un producto seleccionado
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener datos del producto seleccionado
            var selectedProduct = dgvProducts.CurrentRow.DataBoundItem as Product;
            if (selectedProduct == null) return;

            int quantityToAdd = (int)numQuantity.Value;

            // 3. Validar stock
            if (quantityToAdd > selectedProduct.Stock)
            {
                MessageBox.Show($"No hay suficiente stock para '{selectedProduct.Name}'. Stock disponible: {selectedProduct.Stock}", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Verificar si el producto ya está en el carrito para actualizarlo
            var existingCartItem = _shoppingCart.FirstOrDefault(item => item.ProductId == selectedProduct.Id);

            if (existingCartItem != null)
            {
                // Si ya existe, actualiza la cantidad (sin superar el stock)
                if (existingCartItem.Cantidad + quantityToAdd > selectedProduct.Stock)
                {
                    MessageBox.Show($"No puede añadir más unidades de '{selectedProduct.Name}'. Stock disponible: {selectedProduct.Stock}, en carrito: {existingCartItem.Cantidad}", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                existingCartItem.Cantidad += quantityToAdd;
            }
            else
            {
                // Si es nuevo, añadirlo al carrito
                _shoppingCart.Add(new CartItemViewModel
                {
                    ProductId = selectedProduct.Id,
                    Producto = selectedProduct.Name,
                    Cantidad = quantityToAdd,
                    PrecioUnitario = selectedProduct.Price
                });
            }

            // Forzar refresco del DataGridView y actualizar totales
            _shoppingCart.ResetBindings();
            UpdateTotals();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvInvoiceDetails.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un producto del detalle de la factura para quitar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itemToRemove = dgvInvoiceDetails.CurrentRow.DataBoundItem as CartItemViewModel;
            if (itemToRemove != null)
            {
                _shoppingCart.Remove(itemToRemove);
                UpdateTotals();
            }
        }

        private void UpdateTotals()
        {
            decimal total = _shoppingCart.Sum(item => item.SubTotal);
            lblTotal.Text = $"Total: {total:C2}"; // C2 formatea a moneda local
        }

        private async void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            // 1. Validar que hay un cliente seleccionado
            if (cmbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que el carrito no está vacío
            if (!_shoppingCart.Any())
            {
                MessageBox.Show("La factura no tiene productos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Preparar los datos para el servicio
            var customerId = (int)cmbCustomers.SelectedValue;
            var invoiceDetailsDto = _shoppingCart.Select(item => new InvoiceDetailDto(item.ProductId, item.Cantidad, item.PrecioUnitario));

            // 4. Llamar al servicio y manejar el resultado
            try
            {
                await _invoiceService.CreateInvoiceAsync(customerId, invoiceDetailsDto);
                MessageBox.Show("¡Factura creada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                await LoadProductsAsync(); // Recargar productos para ver el stock actualizado
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            _shoppingCart.Clear();
            cmbCustomers.SelectedIndex = 0;
            UpdateTotals();
        }
    }
}
