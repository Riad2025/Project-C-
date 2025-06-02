using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace revisionIsgaG2
{
    public partial class AccueilForm : Form

    {
        private readonly ExamenDao examenDao = new ExamenDao();
        private readonly ModuleDao moduleDao = new ModuleDao();
        private System.Windows.Forms.Timer refreshTimer;

        public AccueilForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeUI();
            LoadData();
            SetupTimer();
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 60000; // 60 secondes
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }



        private void InitializeCustomComponents()
        {
            // Initialisation de la barre de statut
            statusStrip1.Items.Clear();

            lblDbStatus = new ToolStripStatusLabel { Text = "DB: Connecté", BorderSides = ToolStripStatusLabelBorderSides.Right };
            lblUsersOnline = new ToolStripStatusLabel { Text = "Utilisateurs: 0", BorderSides = ToolStripStatusLabelBorderSides.Right };
            lblCurrentTime = new ToolStripStatusLabel { Text = DateTime.Now.ToShortTimeString() };

            statusStrip1.Items.AddRange(new ToolStripItem[] {
                lblDbStatus,
                lblUsersOnline,
                lblCurrentTime
            });
        }
        private void InitializeUI()
        {
            // Configuration de base
            this.Text = "Système de Gestion Scolaire - ISGA";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 650);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Style des panels
            panelNotifications.BackColor = Color.Lavender;
            panelExport.BackColor = Color.Honeydew;
            panelArchive.BackColor = Color.AliceBlue;

            // Configuration des boutons
            btnAdmin.BackColor = Color.SteelBlue;
            btnAdmin.ForeColor = Color.White;
            btnEnseignant.BackColor = Color.SeaGreen;
            btnEnseignant.ForeColor = Color.White;
            btnEtudiant.BackColor = Color.IndianRed;
            btnEtudiant.ForeColor = Color.White;

            // Configuration des ListBox
            ConfigureListBoxes();
        }
        private void ConfigureListBoxes()
        {
            listBoxExams.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxExams.DrawItem += (sender, e) =>
            {
                e.DrawBackground();
                e.Graphics.DrawString(listBoxExams.Items[e.Index].ToString(),
                                    e.Font, Brushes.Black, e.Bounds);
            };
            listBoxResults.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxResults.DrawItem += (sender, e) =>
            {
                e.DrawBackground();
                e.Graphics.DrawString(listBoxResults.Items[e.Index].ToString(),
                                    e.Font, Brushes.Black, e.Bounds);
            };

            listBoxArchives.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxArchives.DrawItem += (sender, e) =>
            {
                e.DrawBackground();
                e.Graphics.DrawString(listBoxArchives.Items[e.Index].ToString(),
                                    e.Font, Brushes.Black, e.Bounds);
            };
        }
        private void SetupTimer()
        {

        }
        private void LoadData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LoadExamNotifications();
                LoadResultPublicationNotifications();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de chargement des données: {ex.Message}", "Erreur",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void LoadExamNotifications()
        {
            var upcomingExams = examenDao.allExams()
                .Where(e => e.Date >= DateTime.Now && e.Date <= DateTime.Now.AddDays(7))
                .OrderBy(e => e.Date)
                .ToList();

            listBoxExams.BeginUpdate();
            listBoxExams.Items.Clear();

            foreach (var exam in upcomingExams)
            {
                var module = moduleDao.findModuleById(exam.Idm);
                listBoxExams.Items.Add($"{exam.Date:dd/MM HH:mm} - {module?.Lib ?? "Inconnu"}");
            }

            listBoxExams.EndUpdate();
            lblExamCount.Text = $"{upcomingExams.Count} examens à venir";
        }

        private void LoadResultPublicationNotifications()
        {
            var publishedResults = examenDao.allExams()
                .Where(e => e.EstPublie && e.Date >= DateTime.Now.AddMonths(-1))
                .OrderByDescending(e => e.Date)
                .ToList();

            listBoxResults.BeginUpdate();
            listBoxResults.Items.Clear();

            foreach (var exam in publishedResults.Take(5))
            {
                var module = moduleDao.findModuleById(exam.Idm);
                listBoxResults.Items.Add($"{module?.Lib ?? "Inconnu"} - Note: {exam.Note} - {exam.Date:dd/MM}");
            }

            listBoxResults.EndUpdate();
            lblResultCount.Text = $"{publishedResults.Count} résultats publiés récemment";
        }


        private void LoadArchives()
        {
            var archives = examenDao.allExams()
                .Where(e => e.Date < DateTime.Now.AddMonths(-6))
                .GroupBy(e => new { e.Date.Year, e.Date.Month })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month)
                .ToList();

            listBoxArchives.BeginUpdate();
            listBoxArchives.Items.Clear();

            foreach (var archive in archives)
            {
                listBoxArchives.Items.Add($"Session {archive.Key.Month}/{archive.Key.Year} - {archive.Count()} examens");
            }

            listBoxArchives.EndUpdate();
        }


        private void CheckForNewNotifications()
        {
            // Vérifier les nouveaux examens ou résultats
            LoadExamNotifications();
            LoadResultPublicationNotifications();

            // Clignoter le bouton de notification si nouveau contenu

        }

        private void listBoxExams_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportData("PDF");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccueilForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new LoginForm(this).Show();
            this.Hide();
        }

        private void btnEnseignant_Click(object sender, EventArgs e)
        {
            new EnseignantLoginForm(this).Show();
            this.Hide();
        }

        private void btnEtudiant_Click(object sender, EventArgs e)
        {
            new EtudiantLoginForm(this).Show();
            this.Hide();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportData("Excel");

        }
        private void ExportData(string format)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = format == "PDF"
                    ? "Fichiers PDF (*.pdf)|*.pdf"
                    : "Fichiers Excel (*.xlsx)|*.xlsx";

                saveDialog.Title = $"Exporter en {format}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (format == "PDF")
                        {
                            ExportToPDF(saveDialog.FileName);
                        }
                        else
                        {
                            ExportToExcel(saveDialog.FileName);
                        }
                        MessageBox.Show($"Export {format} terminé avec succès!", "Succès",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'export {format}: {ex.Message}", "Erreur",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToPDF(string filePath)
        {

        }

        private void ExportToExcel(string filePath)
        {

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();

                // Feuille pour les examens
                Excel.Worksheet examSheet = (Excel.Worksheet)workbook.Sheets[1];
                examSheet.Name = "Examens à venir";

                // En-têtes
                examSheet.Cells[1, 1] = "Date";
                examSheet.Cells[1, 2] = "Module";

                // Données
                for (int i = 0; i < listBoxExams.Items.Count; i++)
                {
                    string[] parts = listBoxExams.Items[i].ToString().Split('-');
                    examSheet.Cells[i + 2, 1] = parts[0].Trim();
                    examSheet.Cells[i + 2, 2] = parts[1].Trim();
                }

                // Feuille pour les résultats
                Excel.Worksheet resultSheet = (Excel.Worksheet)workbook.Sheets.Add();
                resultSheet.Name = "Résultats";

                // En-têtes
                resultSheet.Cells[1, 1] = "Module";
                resultSheet.Cells[1, 2] = "Note";
                resultSheet.Cells[1, 3] = "Date";

                // Données
                for (int i = 0; i < listBoxResults.Items.Count; i++)
                {
                    string[] parts = listBoxResults.Items[i].ToString().Split('-');
                    resultSheet.Cells[i + 2, 1] = parts[0].Trim();
                    resultSheet.Cells[i + 2, 2] = parts[1].Trim().Replace("Note:", "").Trim();
                    resultSheet.Cells[i + 2, 3] = parts[2].Trim();
                }

                // Sauvegarder et fermer
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'export Excel : " + ex.Message);
            }
            finally
            {
                // Libérer les ressources COM
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }

        }

        private void btnViewArchive_Click(object sender, EventArgs e)
        {

            if (listBoxArchives.SelectedItem != null)
            {
                string selectedArchive = listBoxArchives.SelectedItem.ToString();
                var archiveDetails = examenDao.allExams()
                    .Where(e => e.Date.Year == int.Parse(selectedArchive.Split('/')[1])
                    && e.Date.Month == int.Parse(selectedArchive.Split('/')[0].Split(' ')[1]))
                    .ToList();

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une archive à consulter", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportArchive_Click(object sender, EventArgs e)
        {
            if (listBoxArchives.SelectedItem != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Fichiers CSV (*.csv)|*.csv";
                    sfd.FileName = $"Archive_{listBoxArchives.SelectedItem.ToString().Replace("/", "_")}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        ExportArchiveToCSV(sfd.FileName);
                        MessageBox.Show("Archive exportée avec succès !", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une archive à exporter", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportArchiveToCSV(string fileName)
        {
            throw new NotImplementedException();
        }

        private void btnRefreshNotifications_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            InitializeCustomComponents();
        }

        private void panelExport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblExamCount_Click(object sender, EventArgs e)
        {

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            CheckForNewNotifications();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
