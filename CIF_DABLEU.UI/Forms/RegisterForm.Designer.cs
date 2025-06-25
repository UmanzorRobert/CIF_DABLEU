namespace CIF_DABLEU.UI.Forms
{
    partial class RegisterForm
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
            label2 = new Label();
            label3 = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 52);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 107);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 166);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(191, 44);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(153, 23);
            txtFullName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(191, 99);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(153, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(191, 158);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(153, 23);
            txtPassword.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(289, 244);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Registrar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegister;
    }
}