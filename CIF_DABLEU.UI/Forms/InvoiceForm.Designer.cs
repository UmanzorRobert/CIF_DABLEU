namespace CIF_DABLEU.UI.Forms
{
    partial class InvoiceForm
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnAddProduct = new Button();
            numQuantity = new NumericUpDown();
            dgvProducts = new DataGridView();
            cmbCustomers = new ComboBox();
            groupBox2 = new GroupBox();
            btnRemoveProduct = new Button();
            dgvInvoiceDetails = new DataGridView();
            lblTotal = new Label();
            btnCreateInvoice = new Button();
            btnExportPdf = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddProduct);
            groupBox1.Controls.Add(numQuantity);
            groupBox1.Controls.Add(dgvProducts);
            groupBox1.Location = new Point(12, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(696, 233);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Productos Disponibles";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(316, 178);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(94, 38);
            btnAddProduct.TabIndex = 2;
            btnAddProduct.Text = "Añadir a Factura >>";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(123, 188);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 1;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(14, 22);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Size = new Size(661, 150);
            dgvProducts.TabIndex = 0;
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(79, 11);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(121, 23);
            cmbCustomers.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRemoveProduct);
            groupBox2.Controls.Add(dgvInvoiceDetails);
            groupBox2.Location = new Point(12, 297);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(696, 245);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de la Factura";
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.Location = new Point(282, 187);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(84, 38);
            btnRemoveProduct.TabIndex = 1;
            btnRemoveProduct.Text = "Quitar Producto";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // dgvInvoiceDetails
            // 
            dgvInvoiceDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceDetails.Location = new Point(14, 22);
            dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            dgvInvoiceDetails.Size = new Size(661, 150);
            dgvInvoiceDetails.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(156, 557);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(167, 37);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: 0.00€";
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.Location = new Point(395, 557);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(88, 35);
            btnCreateInvoice.TabIndex = 5;
            btnCreateInvoice.Text = "Crear Factura";
            btnCreateInvoice.UseVisualStyleBackColor = true;
            btnCreateInvoice.Click += btnCreateInvoice_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(521, 555);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(90, 39);
            btnExportPdf.TabIndex = 2;
            btnExportPdf.Text = "Exportar a PDF";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 606);
            Controls.Add(btnExportPdf);
            Controls.Add(btnCreateInvoice);
            Controls.Add(lblTotal);
            Controls.Add(groupBox2);
            Controls.Add(cmbCustomers);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "InvoiceForm";
            Text = "InvoiceForm";
            Load += InvoiceForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cmbCustomers;
        private DataGridView dgvProducts;
        private NumericUpDown numQuantity;
        private Button btnAddProduct;
        private GroupBox groupBox2;
        private Button btnRemoveProduct;
        private DataGridView dgvInvoiceDetails;
        private Label lblTotal;
        private Button btnCreateInvoice;
        private Button btnExportPdf;
    }
}