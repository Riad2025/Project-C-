namespace revisionIsgaG2
{
    partial class DashboardEnseignant
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
            lblWelcome = new Label();
            lblSpecialite = new Label();
            comboBoxModules = new ComboBox();
            label1 = new Label();
            btnGestionExamens = new Button();
            btnSaisieNotes = new Button();
            btnStatistiques = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(28, 42);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(50, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "label1";
            // 
            // lblSpecialite
            // 
            lblSpecialite.AutoSize = true;
            lblSpecialite.Location = new Point(28, 88);
            lblSpecialite.Name = "lblSpecialite";
            lblSpecialite.Size = new Size(50, 20);
            lblSpecialite.TabIndex = 1;
            lblSpecialite.Text = "label1";
            // 
            // comboBoxModules
            // 
            comboBoxModules.FormattingEnabled = true;
            comboBoxModules.Location = new Point(251, 169);
            comboBoxModules.Name = "comboBoxModules";
            comboBoxModules.Size = new Size(151, 28);
            comboBoxModules.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 177);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 3;
            label1.Text = "Liste des modules enseignés";
            label1.Click += label1_Click;
            // 
            // btnGestionExamens
            // 
            btnGestionExamens.Location = new Point(69, 255);
            btnGestionExamens.Name = "btnGestionExamens";
            btnGestionExamens.Size = new Size(288, 46);
            btnGestionExamens.TabIndex = 4;
            btnGestionExamens.Text = "Gérer les Examens";
            btnGestionExamens.UseVisualStyleBackColor = true;
            btnGestionExamens.Click += btnGestionExamens_Click;
            // 
            // btnSaisieNotes
            // 
            btnSaisieNotes.Location = new Point(69, 321);
            btnSaisieNotes.Name = "btnSaisieNotes";
            btnSaisieNotes.Size = new Size(288, 46);
            btnSaisieNotes.TabIndex = 5;
            btnSaisieNotes.Text = "Saisir les Notes";
            btnSaisieNotes.UseVisualStyleBackColor = true;
            btnSaisieNotes.Click += btnSaisieNotes_Click;
            // 
            // btnStatistiques
            // 
            btnStatistiques.Location = new Point(69, 388);
            btnStatistiques.Name = "btnStatistiques";
            btnStatistiques.Size = new Size(288, 46);
            btnStatistiques.TabIndex = 6;
            btnStatistiques.Text = "Voir les Statistiques";
            btnStatistiques.UseVisualStyleBackColor = true;
            btnStatistiques.Click += btnStatistiques_Click;
            // 
            // button1
            // 
            button1.Location = new Point(69, 450);
            button1.Name = "button1";
            button1.Size = new Size(288, 46);
            button1.TabIndex = 7;
            button1.Text = "Deconnection";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DashboardEnseignant
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 519);
            Controls.Add(button1);
            Controls.Add(btnStatistiques);
            Controls.Add(btnSaisieNotes);
            Controls.Add(btnGestionExamens);
            Controls.Add(label1);
            Controls.Add(comboBoxModules);
            Controls.Add(lblSpecialite);
            Controls.Add(lblWelcome);
            Name = "DashboardEnseignant";
            Text = "DashboardEnseignant";
            Load += DashboardEnseignant_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblSpecialite;
        private ComboBox comboBoxModules;
        private Label label1;
        private Button btnGestionExamens;
        private Button btnSaisieNotes;
        private Button btnStatistiques;
        private Button button1;
    }
}