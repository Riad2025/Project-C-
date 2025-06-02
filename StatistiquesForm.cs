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

    public partial class StatistiquesForm : Form
    {
        private int moduleId;
        private ExamenDao examenDao = new ExamenDao();

        public StatistiquesForm(int moduleId)
        {
            InitializeComponent();
            this.moduleId = moduleId;
            CalculerStatistiques();
        }
        private void CalculerStatistiques()
        {
            var notes = examenDao.GetNotesByModule(moduleId);

            if (notes.Any())
            {
                double moyenne = notes.Average();
                double tauxReussite = notes.Where(n => n >= 10).Count() * 100.0 / notes.Count;

                lblMoyenne.Text = $"Moyenne: {moyenne:F2}";
                lblTauxReussite.Text = $"Taux de réussite: {tauxReussite:F1}%";


            }
        }
        private void StatistiquesForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter les statistiques ?",
                      "Confirmation",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
