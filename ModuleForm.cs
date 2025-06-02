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
    public partial class ModuleForm : Form
    {
        private readonly ModuleDao moduleDao = new ModuleDao();
        private readonly EnseignantDao enseignantDao = new EnseignantDao();
        public ModuleForm()
        {
            InitializeComponent();
            LoadModules();
            LoadEnseignants();
        }
        private void LoadModules()
        {
            dataGridView1.DataSource = moduleDao.allmodules();
        }
        private void LoadEnseignants()
        {
            comboBoxEnseignant.DataSource = enseignantDao.allEnseignants();
            comboBoxEnseignant.DisplayMember = "Nom";
            comboBoxEnseignant.ValueMember = "Id";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                moduleDao.addModule(
                    int.Parse(textBox1.Text),
                    textBox2.Text,
                    double.Parse(textBox3.Text),
                    (int)comboBoxEnseignant.SelectedValue
                );
                LoadModules();
                MessageBox.Show("Module ajouté avec succès!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var module = moduleDao.findModuleById(int.Parse(textBox1.Text));
            if (module != null)
            {
                textBox2.Text = module.Lib;
                textBox3.Text = module.Coiff.ToString();
                comboBoxEnseignant.SelectedValue = module.IdEnseignant;
            }
            else
            {
                MessageBox.Show("Module non trouvé!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                moduleDao.updateModule(
                    int.Parse(textBox1.Text),
                    textBox2.Text,
                    double.Parse(textBox3.Text),
                    (int)comboBoxEnseignant.SelectedValue
                );
                LoadModules();
                MessageBox.Show("Module modifié avec succès!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                moduleDao.deleteModule(int.Parse(textBox1.Text));
                LoadModules();
                MessageBox.Show("Module supprimé avec succès!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }

        }

        private void ModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
