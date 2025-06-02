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
    public partial class AdminDashboard : Form
    {
        private string currentUsername;
        private string currentRole;
        private AdminDao adminDao = new AdminDao();


        public AdminDashboard()
        {
            InitializeComponent();


        }



        private void button7_Click(object sender, EventArgs e)
        {
            // var form = new SelectionModuleForm(adminDao);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //   string pvPath = adminDao.GenererPV(form.ModuleSelectionne);
            //MessageBox.Show($"PV généré: {pvPath}");
            // System.Diagnostics.Process.Start(pvPath);
            //}
        }

        private void btnGestionEtudiants_Click(object sender, EventArgs e)
        {
            var form = new EtudiantForm();
            form.ShowDialog();
        }

        private void btnGestionEnseignants_Click(object sender, EventArgs e)
        {
            var form = new EnseignantForm();
            form.ShowDialog();
        }

        private void btnGestionModules_Click(object sender, EventArgs e)
        {
            var form = new ModuleForm();
            form.ShowDialog();
        }

        private void btnGestionExamens_Click(object sender, EventArgs e)
        {
            var form = new Examenform();
            form.ShowDialog();
        }

        private void btnValiderNotes_Click(object sender, EventArgs e)
        {
            var form = new ValidationNotesForm(adminDao);
            form.ShowDialog();
        }

        private void btnPublierResultats_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous publier tous les résultats validés?",
               "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                adminDao.PublierResultats();
                MessageBox.Show("Résultats publiés avec succès!");
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var form = new ChangePasswordForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    new AdminDao().ChangePassword(form.NewPassword);
                    MessageBox.Show("Mot de passe changé avec succès");
                }
            }
        }

        private void btnPublierResultats_Click_1(object sender, EventArgs e)
        {
            var form = new PublicationResultatsForm();
            form.ShowDialog();

        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            using (var form = new ChangePasswordForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    new AdminDao().ChangePassword(form.NewPassword);
                    MessageBox.Show("Mot de passe changé avec succès");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?",
                       "Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Journalisation
                LogActivity("Déconnexion administrateur");

                // Retour à l'accueil
                var accueil = new AccueilForm();
                accueil.Show();

                // Fermer ce formulaire
                this.Close();
            }
        }

        private void LogActivity(string activityDescription)
        {
            // Implémentation simple pour journaliser l'activité.  
            // Vous pouvez remplacer cela par une implémentation plus complexe si nécessaire.  
            Console.WriteLine($"Activité: {activityDescription}, Date: {DateTime.Now}");
        }
    }
}
