using System;
using System.Windows.Forms;

namespace MedicalManagment.Views
{
    public partial class frmMain : Form
    {
        private string _userName;
        private bool _isAuthenticated;
        public frmMain(string userName, bool isAuthenticated)
        {
            InitializeComponent();
            _userName = userName;
            _isAuthenticated = isAuthenticated;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var frmLogin = new MedicalManagment.Views.Auth.frmLogin();
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterParent;
            if (!_isAuthenticated)
            {
                this.Hide();
                frmLogin.Show();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmUsers = new frmUsers();
            frmUsers.MdiParent = this;
            frmUsers.StartPosition = FormStartPosition.CenterScreen;
            frmUsers.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmClients = new frmClients();
            frmClients.MdiParent = this;
            frmClients.StartPosition = FormStartPosition.CenterScreen;
            frmClients.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmRoles = new frmRoles(_userName);
            frmRoles.MdiParent = this;
            frmRoles.StartPosition = FormStartPosition.CenterScreen;
            frmRoles.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
