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
    public partial class DashboardEnseignant : Form
    {
        private int enseignantId;
        private EnseignantDao enseignantDao = new EnseignantDao();
        private ExamenDao examenDao = new ExamenDao();
        private ModuleDao moduleDao = new ModuleDao();
        public DashboardEnseignant(int id)
        {
            InitializeComponent();
            enseignantId = id;
            LoadEnseignantInfo();
            LoadModulesEnseignes();
        }
        private void LoadEnseignantInfo()
        {
            var enseignant = enseignantDao.findById(enseignantId);
            lblWelcome.Text = $"Bienvenue, {enseignant.Prenom} {enseignant.Nom}";
            lblSpecialite.Text = $"Spécialité: {enseignant.Specialite}";
        }

        private void LoadModulesEnseignes()
        {
            comboBoxModules.DataSource = moduleDao.GetModulesByEnseignant(enseignantId);
            comboBoxModules.DisplayMember = "Lib";
            comboBoxModules.ValueMember = "Id";
        }
        private void DashboardEnseignant_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGestionExamens_Click(object sender, EventArgs e)
        {
            new Examenform().ShowDialog();

        }

        private void btnSaisieNotes_Click(object sender, EventArgs e)
        {
            if (comboBoxModules.SelectedValue != null)
            {
                new SaisieNotesForm((int)comboBoxModules.SelectedValue).ShowDialog();
            }
        }

        private void btnStatistiques_Click(object sender, EventArgs e)
        {
            if (comboBoxModules.SelectedValue != null)
            {
                new StatistiquesForm((int)comboBoxModules.SelectedValue).ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Demander confirmation  
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Confirmation de déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Fermer le dashboard  
                this.Close();

                // Réafficher le formulaire de login  
                var accueilForm = new AccueilForm(); // Créer une instance d'AccueilForm  
                var loginForm = new EnseignantLoginForm(accueilForm); // Passer l'instance d'AccueilForm au constructeur  
                loginForm.Show();
            }
        }
    }
}
