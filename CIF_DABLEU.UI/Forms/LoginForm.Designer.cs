namespace CIF_DABLEU.UI.Forms
{
    partial class LoginForm
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
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            linkLabelRegister = new LinkLabel();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(130, 109);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(153, 23);
            txtPassword.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(130, 50);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(153, 23);
            txtEmail.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 117);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 7;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 58);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 6;
            label2.Text = "Email:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(190, 168);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 39);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkLabelRegister
            // 
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.Location = new Point(161, 238);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(161, 15);
            linkLabelRegister.TabIndex = 11;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "¿No tienes cuenta? Regístrate";
            linkLabelRegister.LinkClicked += linkLabelRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 450);
            Controls.Add(linkLabelRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label3;
        private Label label2;
        private Button btnLogin;
        private LinkLabel linkLabelRegister;
    }
}