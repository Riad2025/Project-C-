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
    public partial class EtudiantLoginForm : Form
    {
        private EtudiantDao etudiantDao = new EtudiantDao();
        private AccueilForm accueilForm;
        public EtudiantLoginForm(AccueilForm accueilForm)
        {
            InitializeComponent();
            this.Text = "Connexion Étudiant";
            this.accueilForm = accueilForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin_Click(sender, e, etudiantDao);
        }

        private void btnLogin_Click(object sender, EventArgs e, EtudiantDao etudiantDao)
        {
            string nom = txtNom.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir le nom et le mot de passe");
                return;
            }

            try
            {
                Etudiant etudiant = etudiantDao.FindByCredentials(nom, password); // Corrected to use the instance of EtudiantDao  

                if (etudiant != null)
                {
                    // Journalisation de la connexion (optionnel)  
                    LogConnexion(etudiant.Id);

                    // Redirection vers le dashboard  
                    new DashboardEtudiant(etudiant.Id).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect");
                    txtPassword.Clear();
                    txtNom.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion: {ex.Message}");
            }
        }
        private void LogConnexion(int etudiantId)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connexions.log");
            File.AppendAllText(logPath, $"[{DateTime.Now}] Connexion enseignant ID: {etudiantId}\n");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            accueilForm.Show();
        }

        private void EtudiantLoginForm_Load(object sender, EventArgs e)
        {

        }
    }

}
