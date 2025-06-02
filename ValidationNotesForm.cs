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
    public partial class ValidationNotesForm : Form
    {
        private AdminDao adminDao;
        private readonly ExamenDao examenDao = new ExamenDao();
        private List<Examen> examensNonValides;

        public ValidationNotesForm(AdminDao dao)
        {
            InitializeComponent();
            adminDao = dao;
            examenDao = new ExamenDao();
            ConfigurerDataGridView();
            ChargerExamensNonValides();
        }


        private void ConfigurerDataGridView()
        {
            // Désabonner avant de réabonner pour éviter les doublons
            dataGridView.CellContentClick -= DataGridView_CellContentClick;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            // Colonne ID
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdColumn",
                DataPropertyName = "Id",
                HeaderText = "ID Examen"
            });

            // Colonne ID Étudiant
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdeColumn",
                DataPropertyName = "Ide",
                HeaderText = "ID Étudiant"
            });

            // Colonne ID Module
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdmColumn",
                DataPropertyName = "Idm",
                HeaderText = "ID Module"
            });

            // Colonne Note
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NoteColumn",
                DataPropertyName = "Note",
                HeaderText = "Note"
            });

            // Colonne Bouton Valider
            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "ValiderColumn",
                HeaderText = "Action",
                Text = "Valider",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(btnColumn);

            // Réabonner l'événement
            dataGridView.CellContentClick += DataGridView_CellContentClick;
        }

        private void DataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure valid cell indices
            {
                var clickedCell = ((DataGridView)sender!).Rows[e.RowIndex].Cells[e.ColumnIndex];
                
            }
        }

        private void ChargerExamensNonValides()
        {
            examensNonValides = examenDao.allExams()
                .Where(e => !e.EstValide)
                .ToList();

            dataGridView.DataSource = new BindingList<Examen>(examensNonValides);
        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ValiderExamen(int idExamen)
        {
            var examen = examensNonValides.FirstOrDefault(e => e.Id == idExamen);
            if (examen != null)
            {
                examen.EstValide = true;
                examenDao.updateExam(examen.Id, examen.Date, examen.Note, examen.Ide, examen.Idm);

                // Rafraîchir les données
                examensNonValides.Remove(examen);
                dataGridView.DataSource = new BindingList<Examen>(examensNonValides);

                // Rafraîchir le formulaire de publication si ouvert
                var publicationForm = Application.OpenForms.OfType<PublicationResultatsForm>().FirstOrDefault();

                MessageBox.Show("Note validée avec succès !");
            }
        }

        private void ValidationNotesForm_Load(object sender, EventArgs e)
        {
            // Code de chargement si nécessaire
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Votre code existant
            }
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "ValiderColumn")
            {
                int idExamen = (int)dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value;

                examenDao.ValidateExam(idExamen);

                // Rafraîchir l'affichage
                examensNonValides = examenDao.allExams().Where(e => !e.EstValide).ToList();
                dataGridView.DataSource = new BindingList<Examen>(examensNonValides);

                MessageBox.Show("Examen validé avec succès !");
            }
        }
    }
}
