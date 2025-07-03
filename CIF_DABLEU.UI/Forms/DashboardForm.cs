using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CIF_DABLEU.BusinessLogic.Contracts;
using ScottPlot;
using ScottPlot.TickGenerators;

namespace CIF_DABLEU.UI.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IDashboardService _dashboardService;

        public DashboardForm(IDashboardService dashboardService)
        {
            InitializeComponent();
            _dashboardService = dashboardService;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            var data = await _dashboardService.GetDashboardDataAsync();

            // Cargar KPIs
            lblTotalSales.Text = $"Ventas Totales: {data.TotalSales:C2}";
            dgvTopProducts.DataSource = data.TopSellingProducts.ToList();
            if (dgvTopProducts.Columns.Count > 0)
            {
                dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Cargar Gráfico de Productos más vendidos
            if (data.TopSellingProducts.Any())
            {
                var topProductsList = data.TopSellingProducts.ToList();

                double[] quantities = topProductsList
                    .Select(p => Convert.ToDouble(p.GetType().GetProperty("CantidadVendida").GetValue(p)))
                    .ToArray();

                string[] labels = topProductsList
                    .Select(p => (string)p.GetType().GetProperty("Producto").GetValue(p))
                    .ToArray();

                formsPlot1.Plot.Clear();
                formsPlot1.Plot.Add.Bars(quantities);

                var xAxis = formsPlot1.Plot.Axes.Bottom;

                Tick[] ticks = Enumerable.Range(0, labels.Length)
                    .Select(i => new Tick(i, labels[i]))
                    .ToArray();
                xAxis.TickGenerator = new NumericManual(ticks);

                xAxis.TickLabelStyle.Rotation = 45;
                //xAxis.MajorTickStyle.Alignment = Alignment.MiddleCenter; // 'Alignment' ahora es reconocido gracias a 'using ScottPlot;'
                
                // --- CORRECCIÓN DEL TÍTULO ---
                // El acceso al título ahora también es a través de Plot.Axes
                formsPlot1.Plot.Axes.Title.Label.Text = "Top 5 Productos Más Vendidos";

                formsPlot1.Plot.Axes.AutoScale();

                formsPlot1.Refresh();
            }
            // --- FIN DEL CÓDIGO CORREGIDO ---
        }
    }
}
