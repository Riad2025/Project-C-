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
    public partial class EnseignantLoginForm : Form
    {
        private EnseignantDao enseignantDao; // Ajout d'une instance de EnseignantDao  
        private AccueilForm accueilForm;

        public EnseignantLoginForm(AccueilForm accueilForm)
        {
            InitializeComponent();
            this.Text = "Connexion Enseignant";
            enseignantDao = new EnseignantDao(); // Initialisation de l'instance
            this.accueilForm = accueilForm;

        }

        private void EnseignantLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                var enseignant = enseignantDao.FindByCredentials(nom, password);

                if (enseignant != null)
                {
                    // Journalisation de la connexion (optionnel)
                    LogConnexion(enseignant.Id);

                    // Redirection vers le dashboard
                    new DashboardEnseignant(enseignant.Id).Show();
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
        private void LogConnexion(int enseignantId)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connexions.log");
            File.AppendAllText(logPath, $"[{DateTime.Now}] Connexion enseignant ID: {enseignantId}\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            accueilForm.Show();
        }
    }
}
