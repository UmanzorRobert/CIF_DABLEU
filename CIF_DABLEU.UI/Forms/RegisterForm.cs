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

namespace CIF_DABLEU.UI.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IAuthService _authService;

        public RegisterForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var success = await _authService.RegisterUserAsync(txtFullName.Text, txtEmail.Text, txtPassword.Text);
            if (success)
            {
                MessageBox.Show("¡Usuario registrado con éxito! Ahora puede iniciar sesión.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El correo electrónico ya está en uso o ha ocurrido un error.");
            }
        }
    }
}
