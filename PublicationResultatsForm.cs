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
    public partial class PublicationResultatsForm : Form
    {
        private ExamenDao examenDao = new ExamenDao();

        public PublicationResultatsForm()
        {
            InitializeComponent();
            ActualiserAffichage();
        }

        private void ActualiserAffichage()
        {
            var exams = examenDao.allExams();

            // Mettre à jour les labels  
            lblTotal.Text = $"Total: {exams.Count}";
            lblValides.Text = $"Validés: {exams.Count(e => e.EstValide)}";
            lblNonValides.Text = $"Non validés: {exams.Count(e => !e.EstValide)}";
            lblPublies.Text = $"Publiés: {exams.Count(e => e.EstPublie)}";

            // Assurez-vous que dataGridView1 est défini dans le concepteur ou initialisé ici  
            if (dataGridView1 == null)
            {
                dataGridView1 = new DataGridView();
                this.Controls.Add(dataGridView1);
                dataGridView1.Location = new Point(10, 100); // Positionnement arbitraire  
                dataGridView1.Size = new Size(500, 300); // Taille arbitraire  
            }

            // Afficher les examens à publier  
            dataGridView1.DataSource = exams
                .Where(e => e.EstValide && !e.EstPublie)
                .ToList();
        }

        private void btnPublier_Click(object sender, EventArgs e)
        {
            var aPublier = examenDao.allExams()
            .Where(e => e.EstValide && !e.EstPublie)
            .ToList();

            if (aPublier.Count == 0)
            {
                MessageBox.Show("Aucun examen validé disponible pour publication");
                return;
            }

            examenDao.PublierExamens();
            ActualiserAffichage();
            MessageBox.Show($"{aPublier.Count} examens publiés avec succès !");
        }

        // Ajout de la déclaration de dataGridView1  
        private DataGridView dataGridView1;
    }
}
    

