namespace revisionIsgaG2
{
    partial class AdminDashboard
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
            btnGestionEtudiants = new Button();
            btnGestionEnseignants = new Button();
            btnGestionModules = new Button();
            btnGestionExamens = new Button();
            btnValiderNotes = new Button();
            btnPublierResultats = new Button();
            btnChangePassword = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnGestionEtudiants
            // 
            btnGestionEtudiants.Location = new Point(69, 79);
            btnGestionEtudiants.Name = "btnGestionEtudiants";
            btnGestionEtudiants.Size = new Size(162, 51);
            btnGestionEtudiants.TabIndex = 0;
            btnGestionEtudiants.Text = "Gestion Etudiants";
            btnGestionEtudiants.UseVisualStyleBackColor = true;
            btnGestionEtudiants.Click += btnGestionEtudiants_Click;
            // 
            // btnGestionEnseignants
            // 
            btnGestionEnseignants.Location = new Point(249, 79);
            btnGestionEnseignants.Name = "btnGestionEnseignants";
            btnGestionEnseignants.Size = new Size(162, 51);
            btnGestionEnseignants.TabIndex = 1;
            btnGestionEnseignants.Text = "Gestion Enseignants";
            btnGestionEnseignants.UseVisualStyleBackColor = true;
            btnGestionEnseignants.Click += btnGestionEnseignants_Click;
            // 
            // btnGestionModules
            // 
            btnGestionModules.Location = new Point(432, 79);
            btnGestionModules.Name = "btnGestionModules";
            btnGestionModules.Size = new Size(162, 51);
            btnGestionModules.TabIndex = 2;
            btnGestionModules.Text = "Gestion Modules";
            btnGestionModules.UseVisualStyleBackColor = true;
            btnGestionModules.Click += btnGestionModules_Click;
            // 
            // btnGestionExamens
            // 
            btnGestionExamens.Location = new Point(69, 153);
            btnGestionExamens.Name = "btnGestionExamens";
            btnGestionExamens.Size = new Size(162, 51);
            btnGestionExamens.TabIndex = 3;
            btnGestionExamens.Text = "Gestion Examens";
            btnGestionExamens.UseVisualStyleBackColor = true;
            btnGestionExamens.Click += btnGestionExamens_Click;
            // 
            // btnValiderNotes
            // 
            btnValiderNotes.Location = new Point(249, 153);
            btnValiderNotes.Name = "btnValiderNotes";
            btnValiderNotes.Size = new Size(162, 51);
            btnValiderNotes.TabIndex = 4;
            btnValiderNotes.Text = "Valider Notes";
            btnValiderNotes.UseVisualStyleBackColor = true;
            btnValiderNotes.Click += btnValiderNotes_Click;
            // 
            // btnPublierResultats
            // 
            btnPublierResultats.Location = new Point(432, 153);
            btnPublierResultats.Name = "btnPublierResultats";
            btnPublierResultats.Size = new Size(162, 51);
            btnPublierResultats.TabIndex = 5;
            btnPublierResultats.Text = "Publier Resultats";
            btnPublierResultats.UseVisualStyleBackColor = true;
            btnPublierResultats.Click += btnPublierResultats_Click_1;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(69, 260);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(176, 35);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(418, 260);
            button1.Name = "button1";
            button1.Size = new Size(176, 35);
            button1.TabIndex = 8;
            button1.Text = "Deconnecter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 329);
            Controls.Add(button1);
            Controls.Add(btnChangePassword);
            Controls.Add(btnPublierResultats);
            Controls.Add(btnValiderNotes);
            Controls.Add(btnGestionExamens);
            Controls.Add(btnGestionModules);
            Controls.Add(btnGestionEnseignants);
            Controls.Add(btnGestionEtudiants);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load_1;
            ResumeLayout(false);
        }

        #endregion

        private Button btnGestionEtudiants;
        private Button btnGestionEnseignants;
        private Button btnGestionModules;
        private Button btnGestionExamens;
        private Button btnValiderNotes;
        private Button btnPublierResultats;
        private Button btnChangePassword;
        private Button button1;
    }
}