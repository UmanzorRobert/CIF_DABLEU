using CIF_DABLEU.BusinessLogic.Contracts;

namespace CIF_DABLEU.UI
{
    public partial class Form1 : Form
    {
        private readonly IProductService _productService;

        // El IProductService es inyectado aquí automáticamente
        public Form1(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
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
    }
}
