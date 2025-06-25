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
using Microsoft.Extensions.DependencyInjection; // Para resolver el RegisterForm

namespace CIF_DABLEU.UI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        public string? JwtToken { get; private set; }

        public LoginForm(IAuthService authService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var token = await _authService.LoginAsync(txtEmail.Text, txtPassword.Text);
            if (!string.IsNullOrEmpty(token))
            {
                this.JwtToken = token;
                this.DialogResult = DialogResult.OK;//Indica éxito
                this.Close();
            }
            else
            {
                MessageBox.Show("Email o contraseña incorrectos.");
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Usamos el ServiceProvider para crear una instancia de RegisterForm
            var registerForm = _serviceProvider.GetRequiredService<RegisterForm>();
            registerForm.ShowDialog();
        }
    }
}
