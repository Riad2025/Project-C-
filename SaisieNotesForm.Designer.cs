namespace revisionIsgaG2
{
    partial class SaisieNotesForm
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
            dataGridViewEtudiants = new DataGridView();
            btnSauvegarder = new Button();
            btnImporter = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEtudiants).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEtudiants
            // 
            dataGridViewEtudiants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEtudiants.Location = new Point(12, 57);
            dataGridViewEtudiants.Name = "dataGridViewEtudiants";
            dataGridViewEtudiants.RowHeadersWidth = 51;
            dataGridViewEtudiants.RowTemplate.Height = 29;
            dataGridViewEtudiants.Size = new Size(776, 225);
            dataGridViewEtudiants.TabIndex = 0;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Location = new Point(12, 338);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(238, 43);
            btnSauvegarder.TabIndex = 1;
            btnSauvegarder.Text = "Sauvegarder";
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Click += btnSauvegarder_Click;
            // 
            // btnImporter
            // 
            btnImporter.Location = new Point(286, 338);
            btnImporter.Name = "btnImporter";
            btnImporter.Size = new Size(238, 43);
            btnImporter.TabIndex = 2;
            btnImporter.Text = "Importer";
            btnImporter.UseVisualStyleBackColor = true;
            btnImporter.Click += btnImporter_Click;
            // 
            // button1
            // 
            button1.Location = new Point(629, 407);
            button1.Name = "button1";
            button1.Size = new Size(145, 31);
            button1.TabIndex = 3;
            button1.Text = "Retour";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SaisieNotesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnImporter);
            Controls.Add(btnSauvegarder);
            Controls.Add(dataGridViewEtudiants);
            Name = "SaisieNotesForm";
            Text = "SaisieNotesForm";
            Load += SaisieNotesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEtudiants).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewEtudiants;
        private Button btnSauvegarder;
        private Button btnImporter;
        private Button button1;
    }
}