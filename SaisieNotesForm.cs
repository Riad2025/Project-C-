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
    public partial class SaisieNotesForm : Form
    {
        private int moduleId;
        private ExamenDao examenDao = new ExamenDao();
        private EtudiantDao etudiantDao = new EtudiantDao();
        public SaisieNotesForm(int selectedValue)
        {
            InitializeComponent();
            this.moduleId = moduleId;
            LoadEtudiants();
            LoadNotes();
        }

        private void LoadEtudiants()
        {
            // Implémentez cette méthode selon votre modèle de données
            dataGridViewEtudiants.DataSource = etudiantDao.GetEtudiantsByModule(moduleId);
        }

        private void LoadNotes()
        {
            // Créer un DataTable pour stocker les données
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("Prenom", typeof(string));
            dt.Columns.Add("Note", typeof(double));

            // Récupérer les données
            var etudiants = etudiantDao.GetEtudiantsByModule(moduleId);
            var examens = examenDao.allExams()
                                 .Where(e => e.Idm == moduleId)
                                 .ToList();

            // Remplir le DataTable
            foreach (var etudiant in etudiants)
            {
                var examen = examens.FirstOrDefault(e => e.Ide == etudiant.Id);
                dt.Rows.Add(
                    etudiant.Id,
                    etudiant.Nom,
                    etudiant.Prenom,
                    examen?.Note ?? 0.0 // Valeur par défaut si pas de note
                );
            }

            // Lier le DataTable au DataGridView
            dataGridViewEtudiants.DataSource = dt;

            // Configurer l'affichage
            dataGridViewEtudiants.Columns["Note"].DefaultCellStyle.Format = "N2"; // 2 décimales
            dataGridViewEtudiants.Columns["Id"].Visible = false; // Cacher l'ID si nécessaire
        }
        private void SaisieNotesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEtudiants.Rows)
            {
                if (row.IsNewRow) continue;

                int etudiantId = row.Cells["Id"].Value == DBNull.Value || row.Cells["Id"].Value == null
                    ? 0
                    : Convert.ToInt32(row.Cells["Id"].Value);
                double note = Convert.ToDouble(row.Cells["Note"].Value);

                examenDao.AddOrUpdateNote(moduleId, etudiantId, note);
            }

            MessageBox.Show("Notes sauvegardées avec succès!");
        }

        private void btnImporter_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers CSV (*.csv)|*.csv|Fichiers Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath);
                    DataTable dtNotes = new DataTable();

                    // Lire le fichier selon son extension
                    if (fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        dtNotes = ReadCsvFile(filePath);
                    }

                    // Vérifier les colonnes obligatoires
                    if (dtNotes.Columns.Contains("IdEtudiant") && dtNotes.Columns.Contains("Note"))
                    {
                        // Mettre à jour le DataGridView
                        dataGridViewEtudiants.DataSource = dtNotes;
                        MessageBox.Show($"{dtNotes.Rows.Count} notes importées avec succès !");
                    }
                    else
                    {
                        MessageBox.Show("Le fichier doit contenir les colonnes 'IdEtudiant' et 'Note'");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'import: {ex.Message}");
                }
            }
        }

        // Méthode pour lire les fichiers CSV
        private DataTable ReadCsvFile(string filePath)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(filePath))
            {
                // Lire l'en-tête
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header.Trim());
                }

                // Lire les données
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i].Trim();
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter le formulaire de la saisie des notes ?",
                      "Confirmation",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
