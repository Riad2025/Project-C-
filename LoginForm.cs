using System;
using System.Windows.Forms;

namespace revisionIsgaG2
{
    public partial class LoginForm : Form
    {
        private AdminDao adminDao = new AdminDao();
        private AccueilForm accueilForm;
        public LoginForm(AccueilForm accueilForm)
        {
            InitializeComponent();

            if (!adminDao.AdminExists())
            {
                adminDao.CreateAdmin("admin", "admin123");
                MessageBox.Show("Compte admin créé (admin/admin123)");
            }

            this.accueilForm = accueilForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (adminDao.Authenticate(txtUsername.Text, txtPassword.Text))
            {
                new AdminDashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiants incorrects");
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnretour_Click(object sender, EventArgs e)
        {
            this.Hide();
            accueilForm.Show();
        }
    }
}

    