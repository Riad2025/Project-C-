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
    public partial class EnseignantForm : Form

    {
        private readonly EnseignantDao dao = new EnseignantDao();

        public EnseignantForm()
        {
            InitializeComponent();
            LoadEnseignants();

        }
        private void LoadEnseignants()
        {
            dataGridView1.DataSource = dao.allEnseignants();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var ens = dao.findById(int.Parse(txtId.Text));
            if (ens != null)
            {
                txtNom.Text = ens.Nom;
                txtPrenom.Text = ens.Prenom;
                txtSpecialite.Text = ens.Specialite;
                txtPassword.Text = ens.Password;
            }
            else
            {
                MessageBox.Show("Enseignant non trouvé!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dao.AddEnseignant(
                    int.Parse(txtId.Text),
                    txtNom.Text,
                    txtPrenom.Text,
                    txtSpecialite.Text,
                    txtPassword.Text
                );
                LoadEnseignants();
                MessageBox.Show("Enseignant ajouté avec succès!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dao.updateEnseignant(
                    int.Parse(txtId.Text),
                    txtNom.Text,
                    txtPrenom.Text,
                    txtSpecialite.Text,
                    txtPassword.Text
                );
                LoadEnseignants();
                MessageBox.Show("Enseignant modifié avec succès!");
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
                dao.deleteEnseignant(int.Parse(txtId.Text));
                LoadEnseignants();
                MessageBox.Show("Enseignant supprimé avec succès!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }
    }
}
