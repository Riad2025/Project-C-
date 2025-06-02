namespace revisionIsgaG2
{
    partial class AccueilForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdmin = new Button();
            btnEnseignant = new Button();
            btnEtudiant = new Button();
            panelNotifications = new Panel();
            lbl1 = new Label();
            btnRefreshNotifications = new Button();
            lblResultCount = new Label();
            listBoxResults = new ListBox();
            lblExamCount = new Label();
            listBoxExams = new ListBox();
            panelExport = new Panel();
            dateRangePicker = new DateTimePicker();
            comboExportType = new ComboBox();
            btnExportExcel = new Button();
            btnExportPDF = new Button();
            label1 = new Label();
            panelArchive = new Panel();
            comboArchiveYears = new ComboBox();
            btnExportArchive = new Button();
            btnViewArchive = new Button();
            listBoxArchives = new ListBox();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            lblDbStatus = new ToolStripStatusLabel();
            lblUsersOnline = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblCurrentTime = new ToolStripStatusLabel();
            lblWelcome = new Label();
            button1 = new Button();
            panelNotifications.SuspendLayout();
            panelExport.SuspendLayout();
            panelArchive.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(338, 174);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(213, 70);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "Admin";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnEnseignant
            // 
            btnEnseignant.Location = new Point(588, 174);
            btnEnseignant.Name = "btnEnseignant";
            btnEnseignant.Size = new Size(213, 70);
            btnEnseignant.TabIndex = 1;
            btnEnseignant.Text = "Enseignant ";
            btnEnseignant.UseVisualStyleBackColor = true;
            btnEnseignant.Click += btnEnseignant_Click;
            // 
            // btnEtudiant
            // 
            btnEtudiant.Location = new Point(838, 174);
            btnEtudiant.Name = "btnEtudiant";
            btnEtudiant.Size = new Size(213, 70);
            btnEtudiant.TabIndex = 2;
            btnEtudiant.Text = "Etudiant";
            btnEtudiant.UseVisualStyleBackColor = true;
            btnEtudiant.Click += btnEtudiant_Click;
            // 
            // panelNotifications
            // 
            panelNotifications.Controls.Add(lbl1);
            panelNotifications.Controls.Add(btnRefreshNotifications);
            panelNotifications.Controls.Add(lblResultCount);
            panelNotifications.Controls.Add(listBoxResults);
            panelNotifications.Controls.Add(lblExamCount);
            panelNotifications.Controls.Add(listBoxExams);
            panelNotifications.Location = new Point(12, 286);
            panelNotifications.Name = "panelNotifications";
            panelNotifications.Size = new Size(566, 288);
            panelNotifications.TabIndex = 3;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(223, 16);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(105, 20);
            lbl1.TabIndex = 5;
            lbl1.Text = "NOTIFICATION";
            lbl1.Click += lbl1_Click;
            // 
            // btnRefreshNotifications
            // 
            btnRefreshNotifications.Location = new Point(180, 235);
            btnRefreshNotifications.Name = "btnRefreshNotifications";
            btnRefreshNotifications.Size = new Size(161, 38);
            btnRefreshNotifications.TabIndex = 4;
            btnRefreshNotifications.Text = "Refresh";
            btnRefreshNotifications.UseVisualStyleBackColor = true;
            btnRefreshNotifications.Click += btnRefreshNotifications_Click;
            // 
            // lblResultCount
            // 
            lblResultCount.AutoSize = true;
            lblResultCount.Location = new Point(301, 198);
            lblResultCount.Name = "lblResultCount";
            lblResultCount.Size = new Size(128, 20);
            lblResultCount.TabIndex = 3;
            lblResultCount.Text = "Y résultats publiés";
            // 
            // listBoxResults
            // 
            listBoxResults.FormattingEnabled = true;
            listBoxResults.ItemHeight = 20;
            listBoxResults.Location = new Point(301, 61);
            listBoxResults.Name = "listBoxResults";
            listBoxResults.Size = new Size(253, 104);
            listBoxResults.TabIndex = 2;
            listBoxResults.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // lblExamCount
            // 
            lblExamCount.AutoSize = true;
            lblExamCount.Location = new Point(13, 198);
            lblExamCount.Name = "lblExamCount";
            lblExamCount.Size = new Size(128, 20);
            lblExamCount.TabIndex = 1;
            lblExamCount.Text = "X examens à venir";
            lblExamCount.Click += lblExamCount_Click;
            // 
            // listBoxExams
            // 
            listBoxExams.FormattingEnabled = true;
            listBoxExams.ItemHeight = 20;
            listBoxExams.Location = new Point(13, 61);
            listBoxExams.Name = "listBoxExams";
            listBoxExams.Size = new Size(257, 104);
            listBoxExams.TabIndex = 0;
            listBoxExams.SelectedIndexChanged += listBoxExams_SelectedIndexChanged;
            // 
            // panelExport
            // 
            panelExport.Controls.Add(dateRangePicker);
            panelExport.Controls.Add(comboExportType);
            panelExport.Controls.Add(btnExportExcel);
            panelExport.Controls.Add(btnExportPDF);
            panelExport.Controls.Add(label1);
            panelExport.Location = new Point(608, 286);
            panelExport.Name = "panelExport";
            panelExport.Size = new Size(343, 288);
            panelExport.TabIndex = 4;
            panelExport.Paint += panelExport_Paint;
            // 
            // dateRangePicker
            // 
            dateRangePicker.Location = new Point(24, 138);
            dateRangePicker.Name = "dateRangePicker";
            dateRangePicker.Size = new Size(250, 27);
            dateRangePicker.TabIndex = 4;
            // 
            // comboExportType
            // 
            comboExportType.FormattingEnabled = true;
            comboExportType.Location = new Point(24, 80);
            comboExportType.Name = "comboExportType";
            comboExportType.Size = new Size(177, 28);
            comboExportType.TabIndex = 3;
            comboExportType.Text = "Choisir ce qu'exporter";
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(180, 235);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(139, 38);
            btnExportExcel.TabIndex = 2;
            btnExportExcel.Text = "Exporter en Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // btnExportPDF
            // 
            btnExportPDF.Location = new Point(24, 235);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(139, 38);
            btnExportPDF.TabIndex = 1;
            btnExportPDF.Text = "Exporter en PDF";
            btnExportPDF.UseVisualStyleBackColor = true;
            btnExportPDF.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 16);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "EXPORT";
            // 
            // panelArchive
            // 
            panelArchive.Controls.Add(comboArchiveYears);
            panelArchive.Controls.Add(btnExportArchive);
            panelArchive.Controls.Add(btnViewArchive);
            panelArchive.Controls.Add(listBoxArchives);
            panelArchive.Controls.Add(label2);
            panelArchive.Location = new Point(981, 286);
            panelArchive.Name = "panelArchive";
            panelArchive.Size = new Size(363, 288);
            panelArchive.TabIndex = 5;
            panelArchive.Paint += panel1_Paint;
            // 
            // comboArchiveYears
            // 
            comboArchiveYears.FormattingEnabled = true;
            comboArchiveYears.Location = new Point(20, 180);
            comboArchiveYears.Name = "comboArchiveYears";
            comboArchiveYears.Size = new Size(151, 28);
            comboArchiveYears.TabIndex = 5;
            // 
            // btnExportArchive
            // 
            btnExportArchive.Location = new Point(197, 235);
            btnExportArchive.Name = "btnExportArchive";
            btnExportArchive.Size = new Size(120, 38);
            btnExportArchive.TabIndex = 4;
            btnExportArchive.Text = "Exporter";
            btnExportArchive.UseVisualStyleBackColor = true;
            btnExportArchive.Click += btnExportArchive_Click;
            // 
            // btnViewArchive
            // 
            btnViewArchive.Location = new Point(49, 235);
            btnViewArchive.Name = "btnViewArchive";
            btnViewArchive.Size = new Size(120, 38);
            btnViewArchive.TabIndex = 2;
            btnViewArchive.Text = "Consulter";
            btnViewArchive.UseVisualStyleBackColor = true;
            btnViewArchive.Click += btnViewArchive_Click;
            // 
            // listBoxArchives
            // 
            listBoxArchives.FormattingEnabled = true;
            listBoxArchives.ItemHeight = 20;
            listBoxArchives.Location = new Point(20, 61);
            listBoxArchives.Name = "listBoxArchives";
            listBoxArchives.Size = new Size(327, 104);
            listBoxArchives.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 16);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 0;
            label2.Text = "ARCHIVE";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblDbStatus, lblUsersOnline, toolStripStatusLabel1, lblCurrentTime });
            statusStrip1.Location = new Point(0, 588);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1356, 26);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // lblDbStatus
            // 
            lblDbStatus.Name = "lblDbStatus";
            lblDbStatus.Size = new Size(0, 20);
            // 
            // lblUsersOnline
            // 
            lblUsersOnline.Name = "lblUsersOnline";
            lblUsersOnline.Size = new Size(151, 20);
            lblUsersOnline.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(151, 20);
            lblCurrentTime.Text = "toolStripStatusLabel2";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(588, 72);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(209, 20);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "Bienvenue sur le système ISGA";
            // 
            // button1
            // 
            button1.Location = new Point(1250, 174);
            button1.Name = "button1";
            button1.Size = new Size(94, 70);
            button1.TabIndex = 8;
            button1.Text = "Fermer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // AccueilForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1356, 614);
            Controls.Add(button1);
            Controls.Add(lblWelcome);
            Controls.Add(statusStrip1);
            Controls.Add(panelArchive);
            Controls.Add(panelExport);
            Controls.Add(panelNotifications);
            Controls.Add(btnEtudiant);
            Controls.Add(btnEnseignant);
            Controls.Add(btnAdmin);
            Name = "AccueilForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccueilForm";
            Load += AccueilForm_Load;
            panelNotifications.ResumeLayout(false);
            panelNotifications.PerformLayout();
            panelExport.ResumeLayout(false);
            panelExport.PerformLayout();
            panelArchive.ResumeLayout(false);
            panelArchive.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdmin;
        private Button btnEnseignant;
        private Button btnEtudiant;
        private Panel panelNotifications;
        private ListBox listBoxExams;
        private Label lblExamCount;
        private ListBox listBoxResults;
        private Button btnRefreshNotifications;
        private Label lblResultCount;
        private Label lbl1;
        private Panel panelExport;
        private Label label1;
        private Button btnExportExcel;
        private Button btnExportPDF;
        private ComboBox comboExportType;
        private DateTimePicker dateRangePicker;
        private Panel panelArchive;
        private ListBox listBoxArchives;
        private Label label2;
        private Button btnExportArchive;
        private Button btnViewArchive;
        private ComboBox comboArchiveYears;
        private StatusStrip statusStrip1;
        private Label lblWelcome;
        private ToolStripStatusLabel lblDbStatus;
        private ToolStripStatusLabel lblUsersOnline;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblCurrentTime;
        private Button button1;
    }
}