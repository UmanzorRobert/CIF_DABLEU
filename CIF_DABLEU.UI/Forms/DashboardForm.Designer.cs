namespace CIF_DABLEU.UI.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTotalSales = new Label();
            groupBox1 = new GroupBox();
            dgvTopProducts = new DataGridView();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).BeginInit();
            SuspendLayout();
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalSales.Location = new Point(22, 9);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(293, 37);
            lblTotalSales.TabIndex = 0;
            lblTotalSales.Text = "Ventas Totales: 0.00 €";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvTopProducts);
            groupBox1.Location = new Point(22, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(766, 193);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Productos más Vendidos";
            // 
            // dgvTopProducts
            // 
            dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopProducts.Location = new Point(19, 22);
            dgvTopProducts.Name = "dgvTopProducts";
            dgvTopProducts.Size = new Size(723, 150);
            dgvTopProducts.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(182, 259);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(458, 172);
            formsPlot1.TabIndex = 2;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(formsPlot1);
            Controls.Add(groupBox1);
            Controls.Add(lblTotalSales);
            Name = "DashboardForm";
            Text = "DashboardForm";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalSales;
        private GroupBox groupBox1;
        private DataGridView dgvTopProducts;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
    }
}