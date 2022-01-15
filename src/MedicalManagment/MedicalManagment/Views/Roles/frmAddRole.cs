using MedicalManagment.Controllers;
using MedicalManagment.Models;
using System;
using System.Windows.Forms;

namespace MedicalManagment.Views.Roles
{
    public partial class frmAddRole : Form
    {
        private readonly RoleController roleController;
        private string _userName;
        public frmAddRole(string userName)
        {
            InitializeComponent();
            roleController = new RoleController();
            _userName = userName;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                MessageBox.Show("Debe de introducir un rol");
                return;
            }
            var role = new Role
            {
                Id = Guid.NewGuid(),
                RoleName = txtRoleName.Text,
                CreatedBy = _userName,
                CreatedOn = DateTime.Now,
                IsCreated = true,
                DeletedBy = "",
                DeletedOn = (default),
                IsDeleted = false,
                IsUpdated = false,
                UpdatedBy = "",
                UpdatedOn = (default)
            };
            var isCreated = await roleController.AddRoleAsync(role);
            MessageBox.Show(isCreated ? "El rol fue creado exitosamente." : "Inconvenientes al crear el rol.");
        }
    }
}
