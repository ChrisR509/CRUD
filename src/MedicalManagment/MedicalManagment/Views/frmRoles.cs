using MedicalManagment.Controllers;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManagment.Views
{
    public partial class frmRoles : Form
    {
        private readonly RoleController roleController;
        private string _userName;
        public frmRoles(string userName)
        {
            InitializeComponent();
            roleController = new RoleController();
            _userName = userName;
        }

        private async void frmRoles_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAddRole = new MedicalManagment.Views.Roles.frmAddRole(_userName);
            frmAddRole.StartPosition = FormStartPosition.CenterScreen;
            frmAddRole.ShowDialog();
        }
        private async Task LoadData()
        {
            var roles = await roleController.GetRolesAsync();
            var table = new DataTable();
            foreach (var rol in roles)
            {
                table.Columns.Add(rol.RoleName);
            }
            dgvRoles.DataSource = table;
        }
    }
}
