using MedicalManagment.Abstracts;
using MedicalManagment.Controllers;
using MedicalManagment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManagment.Views.Auth
{
    public partial class frmLogin : Form
    {
        private readonly AuthController authController;
        public frmLogin()
        {
            InitializeComponent();
            authController = new AuthController();
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe introducir un usuario y contraseña");
                return;
            }
            var (isSuccess, currentUser, errorMessage) = await authController.VerifyUser(txtUser.Text, txtPassword.Text);
            if (errorMessage != null) MessageBox.Show(errorMessage);
            if (isSuccess)
            {
                var frmMain = new frmMain(currentUser.UserName, true);
                frmMain.Show();
                this.Hide();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
