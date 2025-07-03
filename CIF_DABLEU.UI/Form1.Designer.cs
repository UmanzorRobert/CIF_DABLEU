namespace CIF_DABLEU.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            btnSeedData = new Button();
            btnNewInvoice = new Button();
            btnViewDashboard = new Button();
            btnExportExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(79, 297);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(79, 101);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(596, 150);
            dataGridView1.TabIndex = 1;
            // 
            // btnSeedData
            // 
            btnSeedData.Location = new Point(190, 284);
            btnSeedData.Name = "btnSeedData";
            btnSeedData.Size = new Size(108, 48);
            btnSeedData.TabIndex = 2;
            btnSeedData.Text = "Cargar Datos de Prueba";
            btnSeedData.UseVisualStyleBackColor = true;
            btnSeedData.Click += btnSeedData_Click;
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.Location = new Point(340, 284);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(97, 48);
            btnNewInvoice.TabIndex = 3;
            btnNewInvoice.Text = "Nueva Factura";
            btnNewInvoice.UseVisualStyleBackColor = true;
            btnNewInvoice.Click += btnNewInvoice_Click;
            // 
            // btnViewDashboard
            // 
            btnViewDashboard.Location = new Point(465, 284);
            btnViewDashboard.Name = "btnViewDashboard";
            btnViewDashboard.Size = new Size(84, 48);
            btnViewDashboard.TabIndex = 4;
            btnViewDashboard.Text = "Ver Dashboard";
            btnViewDashboard.UseVisualStyleBackColor = true;
            btnViewDashboard.Click += btnViewDashboard_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(568, 284);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(101, 56);
            btnExportExcel.TabIndex = 5;
            btnExportExcel.Text = "Exportar Productos a Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportExcel);
            Controls.Add(btnViewDashboard);
            Controls.Add(btnNewInvoice);
            Controls.Add(btnSeedData);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button btnSeedData;
        private Button btnNewInvoice;
        private Button btnViewDashboard;
        private Button btnExportExcel;
    }
}
