using MedicalManagment.Controllers;
using MetroFramework.Forms;
using System;

namespace MedicalManagment.Views.User
{
    public partial class frmUser : MetroForm
    {
        private readonly UserController userController;
        public frmUser()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private async void frmUser_Load(object sender, EventArgs e)
        {
            var allUsers = await userController.GetAll();
        }
    }
}
