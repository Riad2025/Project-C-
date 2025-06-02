using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revisionIsgaG2
{
    public partial class ChangePasswordForm : Form
    {
        public string NewPassword { get; private set; }

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas");
                return;
            }

            NewPassword = txtNewPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
