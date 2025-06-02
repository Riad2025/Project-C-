using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace revisionIsgaG2
{
    public partial class DashboardEtudiant : Form
    {
        private int etudiantId;
        private ExamenDao examenDao = new ExamenDao();
        private ModuleDao moduleDao = new ModuleDao();
        private EtudiantDao etudiantDao = new EtudiantDao();
        private TabControl tabControl1;
        private System.Windows.Forms.Timer timer;


        public DashboardEtudiant(int id)
        {
            InitializeComponent();
            etudiantId = id;
            InitialiserUI();
            ChargerDonnees();
            InitialiserTimer();
        }

        private void InitialiserUI()
        {
            // Configuration de base
            this.Text = "Tableau de Bord Étudiant";
            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            

            // Configurer les DataGridViews
            ConfigurerGridView(dgvExamens);
            ConfigurerGridView(dgvNotes);

           

            

            
            

            // Barre d'état
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblHeure.Text = DateTime.Now.ToShortTimeString();
        }
        private void InitialiserTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 seconde
            timer.Tick += (s, e) => lblHeure.Text = DateTime.Now.ToShortTimeString();
            timer.Start();
        }
        private void ConfigurerGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }





        private void ChargerDonnees()
        {
            // Info étudiant
            var etudiant = etudiantDao.findById(etudiantId);
            lblNomEtudiant.Text = $"{etudiant.Nom}, {etudiant.Prenom}";
            lblIdEtudiant.Text = $"ID: {etudiant.Id}";

            // Examens à venir
            var examens = examenDao.GetExamensByEtudiant(etudiantId)
                             .Where(e => e.Date >= DateTime.Now)
                             .OrderBy(e => e.Date)
                             .ToList();

            dgvExamens.DataSource = examens.Select(e => new
            {
                e.Id,
                Module = moduleDao.findModuleById(e.Idm)?.Lib ?? "Inconnu",
                Date = e.Date.ToString("dd/MM/yyyy"),
                Heure = e.Date.ToString("HH:mm"),
                Salle = "A définir",
                Durée = "2h"
            }).ToList();

            // Notes
            var notes = examenDao.GetNotesByEtudiant(etudiantId);
            dgvNotes.DataSource = notes.Select(n => new
            {
                Module = moduleDao.findModuleById(n.Idm)?.Lib ?? "Inconnu",
                Note = n.Note.ToString("0.00"),
                Coefficient = moduleDao.findModuleById(n.Idm)?.Coiff.ToString("0.0") ?? "1.0",
                Date = n.Date.ToString("dd/MM/yyyy"),
                Statut = n.EstPublie ? "Validé" : "Non validé"
            }).ToList();

            // Calcul des statistiques
            if (notes.Any())
            {
                double moyenne = notes.Average(n => n.Note);
                lblMoyenneGenerale.Text = $"Moyenne: {moyenne:0.00}/20";
                progressBarReussite.Value = (int)(moyenne * 5); // Convertir en %

                // Mise à jour du graphique

            }
        }

        private void DashboardEtudiant_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblClassement_Click(object sender, EventArgs e)
        {

        }

        private void btnTelechargerReleve_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Fichiers PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Releve_Notes_{etudiantId}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    GenererRelevePDF(sfd.FileName);
                    MessageBox.Show("Relevé téléchargé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenererRelevePDF(string filePath)
        {
            try
            {
                // Implémentation basique avec iTextSharp
                // (Voir l'implémentation complète fournie précédemment)
                MessageBox.Show("Fonctionnalité d'export PDF à implémenter", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération du PDF: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Confirmation",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new AccueilForm().Show();
            }

        }

        private void btnVoirDetails_Click(object sender, EventArgs e)
        {
            if (dgvExamens.SelectedRows.Count > 0)
            {
                int idExamen = (int)dgvExamens.SelectedRows[0].Cells["Id"].Value;
                var examen = examenDao.findExamById(idExamen);
                var module = moduleDao.findModuleById(examen.Idm);

                string details = $"Module: {module?.Lib ?? "Inconnu"}\n" +
                                $"Date: {examen.Date:dd/MM/yyyy HH:mm}\n" +
                                $"Durée: 2 heures\n" +
                                $"Salle: A définir\n" +
                                $"Enseignant: À préciser";

                MessageBox.Show(details, "Détails de l'examen",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un examen", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panelStats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeconnexion_Click_1(object sender, EventArgs e)
        {
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
                var loginForm = new EtudiantLoginForm(accueilForm); // Passer l'instance d'AccueilForm au constructeur  
                loginForm.Show();
            }
        }

        private void lblNotifications_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
