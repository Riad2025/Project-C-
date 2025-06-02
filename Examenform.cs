using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace revisionIsgaG2
{
    public partial class Examenform : Form
    {
        EtudiantDao edao;
        ExamenDao dao;

        public Examenform()
        {
            InitializeComponent();
            edao = new EtudiantDao();
            dao = new ExamenDao();
        }

        private void Examenform_Load(object sender, EventArgs e)
        {
            List<Etudiant> ets = edao.alletudiants();
            foreach (Etudiant et in ets)
            {
                comboBox1.Items.Add(et.Id);
            }

            ModuleDao mdao = new ModuleDao();
            List<Module> mods = mdao.allmodules();
            foreach (Module m in mods)
            {
                comboBox2.Items.Add(m.Id);
            }
            

            dataGridView1.DataSource = dao.allExams();
            dataGridView1.Columns[0].HeaderText = "ID ";
            dataGridView1.Columns[1].HeaderText = "Date ";
            dataGridView1.Columns[2].HeaderText = "Note ";
            dataGridView1.Columns[3].HeaderText = "IDE";
            dataGridView1.Columns[4].HeaderText = "IDM";
            
            dataGridView1.AllowUserToAddRows = false; // Désactiver l'ajout de lignes par l'utilisateur
            dataGridView1.AllowUserToDeleteRows = false; // Désactiver la suppression de lignes par l'utilisateur
            dataGridView1.ReadOnly = true; // Rendre le DataGridView en lecture seule
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Sélectionner la ligne entière
            dataGridView1.MultiSelect = false; // Désactiver la sélection multiple
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajuster la taille des colonnes


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            DateTime date = DateTime.Parse(textBox2.Text);
            double note = Double.Parse(textBox3.Text);
            int ide = Int32.Parse(comboBox1.Text);
            int idm = Int32.Parse(comboBox2.Text);

            // Create an instance of Examen with the provided data  
            Examen examen = new Examen
            {
                Id = id,
                Date = date,
                Note = note,
                Ide = ide,
                Idm = idm
            };

            // Pass the examen object to the addExam method  
            dao.addExam(examen);
            MessageBox.Show("Examen ajouté.");
            dataGridView1.DataSource = dao.allExams();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            Examen ex = dao.findExamById(id);
            if (ex != null)
            {
                textBox2.Text = ex.Date.ToString();
                textBox3.Text = ex.Note.ToString();
                comboBox1.Text = ex.Ide.ToString();
                comboBox2.Text = ex.Idm.ToString();
            }
            else
            {
                MessageBox.Show("Examen non trouvé.");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            dao.deleteExam(id);
            MessageBox.Show("Examen supprimé.");

            dataGridView1.DataSource = dao.allExams();
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            // Vérifier si un étudiant est sélectionné
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Veuillez sélectionner un étudiant dans la liste.");
                return;
            }

            // Récupérer l'ID de l'étudiant à partir de la ComboBox
            int ide;
            if (!Int32.TryParse(comboBox1.Text, out ide))
            {
                MessageBox.Show("L'ID de l'étudiant n'est pas valide.");
                return;
            }

            // Calculer la moyenne
            double moy = dao.moyenne(ide);

            // Afficher la moyenne dans une MessageBox
            MessageBox.Show("La moyenne pour l'étudiant " + ide + " est : " + moy.ToString("F2"));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dao.allExams();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            DateTime date = DateTime.Parse(textBox2.Text);
            double note = Double.Parse(textBox3.Text);
            int ide = Int32.Parse(comboBox1.Text);
            int idm = Int32.Parse(comboBox2.Text);
            dao.updateExam(id, date, note, ide, idm);
            MessageBox.Show("Examen modifié.");


            dataGridView1.DataSource = dao.allExams();
        }
    }
}