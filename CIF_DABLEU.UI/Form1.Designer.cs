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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(274, 296);
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
            btnSeedData.Location = new Point(428, 283);
            btnSeedData.Name = "btnSeedData";
            btnSeedData.Size = new Size(108, 48);
            btnSeedData.TabIndex = 2;
            btnSeedData.Text = "Cargar Datos de Prueba";
            btnSeedData.UseVisualStyleBackColor = true;
            btnSeedData.Click += btnSeedData_Click;
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.Location = new Point(578, 283);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(97, 48);
            btnNewInvoice.TabIndex = 3;
            btnNewInvoice.Text = "Nueva Factura";
            btnNewInvoice.UseVisualStyleBackColor = true;
            btnNewInvoice.Click += btnNewInvoice_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
