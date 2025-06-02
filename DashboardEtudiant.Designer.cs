namespace revisionIsgaG2
{
    partial class DashboardEtudiant
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
            lblNomEtudiant = new Label();
            lblIdEtudiant = new Label();
            lblTitre = new Label();
            btnDeconnexion = new Button();
            dgvExamens = new DataGridView();
            btnVoirDetails = new Button();
            btnImprimerEmploi = new Button();
            dgvNotes = new DataGridView();
            btnTelechargerReleve = new Button();
            panelStats = new Panel();
            lblClassement = new Label();
            lblMoyenneGenerale = new Label();
            statusStrip1 = new StatusStrip();
            lblDate = new ToolStripStatusLabel();
            lblHeure = new ToolStripStatusLabel();
            lblNotifications = new ToolStripStatusLabel();
            progressBarReussite = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvExamens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            panelStats.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNomEtudiant
            // 
            lblNomEtudiant.AutoSize = true;
            lblNomEtudiant.Location = new Point(35, 112);
            lblNomEtudiant.Name = "lblNomEtudiant";
            lblNomEtudiant.Size = new Size(50, 20);
            lblNomEtudiant.TabIndex = 0;
            lblNomEtudiant.Text = "label1";
            // 
            // lblIdEtudiant
            // 
            lblIdEtudiant.AutoSize = true;
            lblIdEtudiant.Location = new Point(35, 159);
            lblIdEtudiant.Name = "lblIdEtudiant";
            lblIdEtudiant.Size = new Size(50, 20);
            lblIdEtudiant.TabIndex = 1;
            lblIdEtudiant.Text = "label2";
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Location = new Point(431, 37);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(176, 20);
            lblTitre.TabIndex = 2;
            lblTitre.Text = "Tableau de Bord Étudiant";
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.Location = new Point(898, 492);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(117, 29);
            btnDeconnexion.TabIndex = 4;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = true;
            btnDeconnexion.Click += btnDeconnexion_Click_1;
            // 
            // dgvExamens
            // 
            dgvExamens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExamens.Location = new Point(35, 232);
            dgvExamens.Name = "dgvExamens";
            dgvExamens.RowHeadersWidth = 51;
            dgvExamens.RowTemplate.Height = 29;
            dgvExamens.Size = new Size(301, 207);
            dgvExamens.TabIndex = 5;
            // 
            // btnVoirDetails
            // 
            btnVoirDetails.Location = new Point(35, 469);
            btnVoirDetails.Name = "btnVoirDetails";
            btnVoirDetails.Size = new Size(120, 52);
            btnVoirDetails.TabIndex = 6;
            btnVoirDetails.Text = "Voir détails";
            btnVoirDetails.UseVisualStyleBackColor = true;
            btnVoirDetails.Click += btnVoirDetails_Click;
            // 
            // btnImprimerEmploi
            // 
            btnImprimerEmploi.Location = new Point(161, 469);
            btnImprimerEmploi.Name = "btnImprimerEmploi";
            btnImprimerEmploi.Size = new Size(175, 52);
            btnImprimerEmploi.TabIndex = 7;
            btnImprimerEmploi.Text = "Imprimer mon emploi du temps";
            btnImprimerEmploi.UseVisualStyleBackColor = true;
            btnImprimerEmploi.Click += button1_Click;
            // 
            // dgvNotes
            // 
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Location = new Point(386, 232);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.RowHeadersWidth = 51;
            dgvNotes.RowTemplate.Height = 29;
            dgvNotes.Size = new Size(301, 207);
            dgvNotes.TabIndex = 8;
            // 
            // btnTelechargerReleve
            // 
            btnTelechargerReleve.Location = new Point(386, 469);
            btnTelechargerReleve.Name = "btnTelechargerReleve";
            btnTelechargerReleve.Size = new Size(162, 52);
            btnTelechargerReleve.TabIndex = 9;
            btnTelechargerReleve.Text = "Télécharger le relevé complet";
            btnTelechargerReleve.UseVisualStyleBackColor = true;
            btnTelechargerReleve.Click += btnTelechargerReleve_Click;
            // 
            // panelStats
            // 
            panelStats.Controls.Add(progressBarReussite);
            panelStats.Controls.Add(lblClassement);
            panelStats.Controls.Add(lblMoyenneGenerale);
            panelStats.Location = new Point(739, 232);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(276, 207);
            panelStats.TabIndex = 10;
            panelStats.Paint += panelStats_Paint;
            // 
            // lblClassement
            // 
            lblClassement.AutoSize = true;
            lblClassement.Location = new Point(27, 99);
            lblClassement.Name = "lblClassement";
            lblClassement.Size = new Size(50, 20);
            lblClassement.TabIndex = 1;
            lblClassement.Text = "label1";
            lblClassement.Click += lblClassement_Click;
            // 
            // lblMoyenneGenerale
            // 
            lblMoyenneGenerale.AutoSize = true;
            lblMoyenneGenerale.Location = new Point(27, 33);
            lblMoyenneGenerale.Name = "lblMoyenneGenerale";
            lblMoyenneGenerale.Size = new Size(50, 20);
            lblMoyenneGenerale.TabIndex = 0;
            lblMoyenneGenerale.Text = "label1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblDate, lblHeure, lblNotifications });
            statusStrip1.Location = new Point(0, 577);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1041, 26);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // lblDate
            // 
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(151, 20);
            lblDate.Text = "toolStripStatusLabel2";
            // 
            // lblHeure
            // 
            lblHeure.Name = "lblHeure";
            lblHeure.Size = new Size(151, 20);
            lblHeure.Text = "toolStripStatusLabel1";
            // 
            // lblNotifications
            // 
            lblNotifications.Name = "lblNotifications";
            lblNotifications.Size = new Size(151, 20);
            lblNotifications.Text = "toolStripStatusLabel1";
            lblNotifications.Click += lblNotifications_Click;
            // 
            // progressBarReussite
            // 
            progressBarReussite.Location = new Point(27, 154);
            progressBarReussite.Name = "progressBarReussite";
            progressBarReussite.Size = new Size(125, 29);
            progressBarReussite.TabIndex = 2;
            // 
            // DashboardEtudiant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 603);
            Controls.Add(statusStrip1);
            Controls.Add(panelStats);
            Controls.Add(btnTelechargerReleve);
            Controls.Add(dgvNotes);
            Controls.Add(btnImprimerEmploi);
            Controls.Add(btnVoirDetails);
            Controls.Add(dgvExamens);
            Controls.Add(btnDeconnexion);
            Controls.Add(lblTitre);
            Controls.Add(lblIdEtudiant);
            Controls.Add(lblNomEtudiant);
            Name = "DashboardEtudiant";
            Text = "DashboardEtudiant";
            Load += DashboardEtudiant_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExamens).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomEtudiant;
        private Label lblIdEtudiant;
        private Label lblTitre;
        private Button btnDeconnexion;
        private DataGridView dgvExamens;
        private Button btnVoirDetails;
        private Button btnImprimerEmploi;
        private DataGridView dgvNotes;
        private Button btnTelechargerReleve;
        private Panel panelStats;
        private Label lblMoyenneGenerale;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblDate;
        private ToolStripStatusLabel lblHeure;
        private ToolStripStatusLabel lblNotifications;
        private Label lblClassement;
        private ProgressBar progressBarReussite;
    }
}