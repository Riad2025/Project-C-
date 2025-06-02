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
    public partial class EtudiantForm : Form
    {
        EtudiantDao dao;
        public EtudiantForm()
        {
            InitializeComponent();
            dao = new EtudiantDao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string prenom = textBox3.Text;
            string password = txtPassword.Text;
            dao.addEtudiant(id, nom, prenom, password);

            dataGridView1.DataSource = dao.alletudiants();
        }

        private void EtudiantForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dao.alletudiants();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            Etudiant et = dao.findById(id);
            textBox2.Text = et.Nom;
            textBox3.Text = et.Prenom;
            txtPassword.Text = et.Password;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            dao.deleteEtudiant(id);

            dataGridView1.DataSource = dao.alletudiants();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBox1.Text);
            string nom = textBox2.Text;
            string prenom = textBox3.Text;
            string password = txtPassword.Text;
            dao.updateEtudiant(id, nom, prenom, password);

            dataGridView1.DataSource = dao.alletudiants();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
