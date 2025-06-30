using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Repositories;
using CIF_DABLEU.UI.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace CIF_DABLEU.UI
{
    public partial class Form1 : Form
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;

        // El IProductService es inyectado aquí automáticamente
        public Form1(IProductService productService, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos un producto de prueba
                var newProduct = new Entities.Models.Product
                {
                    Name = $"Producto de Prueba {DateTime.Now.Ticks}",
                    Description = "Un producto creado para probar la arquitectura",
                    Price = 19.99m,
                    Stock = 100
                };
                await _productService.CreateProductAsync(newProduct);
                MessageBox.Show("¡Producto creado con éxito!");

                // Obtenemos y mostramos todos los productos en el DataGridView
                var allProducts = await _productService.GetAllProductsAsync();
                dataGridView1.DataSource = allProducts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSeedData_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si ya existen productos para no duplicar
                var products = await _unitOfWork.Product.GetAllAsync();
                if (!products.Any())
                {
                    _unitOfWork.Product.AddAsync(new Entities.Models.Product { Name = "Laptop Gamer Pro", Price = 1250.50m, Stock = 15 });
                    _unitOfWork.Product.AddAsync(new Entities.Models.Product { Name = "Mouse Inalámbrico RGB", Price = 45.00m, Stock = 50 });
                    _unitOfWork.Product.AddAsync(new Entities.Models.Product { Name = "Teclado Mecánico TKL", Price = 89.99m, Stock = 30 });
                }

                // Verificar si ya existen clientes para no duplicar
                // Primero necesitamos el repositorio... lo crearemos en el siguiente paso.
                // Por ahora, dejamos esto listo.
                var customerRepo = _unitOfWork.GetType().GetProperty("Customer")?.GetValue(_unitOfWork, null);
                if (customerRepo != null)
                {
                    var customers = await _unitOfWork.Customer.GetAllAsync();
                    if (!customers.Any())
                    {
                        await (customerRepo as IRepository<Entities.Models.Customer>)!.AddAsync(new Entities.Models.Customer { Name = "Consumidor Final", Address = "N/A", Phone = "999999999" });
                        await (customerRepo as IRepository<Entities.Models.Customer>)!.AddAsync(new Entities.Models.Customer { Name = "Empresa ABC S.L.", Address = "Calle Falsa 123", Phone = "123456789" });
                    }
                }

                await _unitOfWork.SaveAsync();
                MessageBox.Show("Datos de prueba cargados/verificados con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            // Program.ServiceProvider debe ser accesible. Si no, inyecta IServiceProvider en Form1
            var invoiceForm = Program.ServiceProvider.GetRequiredService<InvoiceForm>();
            invoiceForm.ShowDialog();
        }
    }
}
