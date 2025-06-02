namespace revisionIsgaG2
{
    partial class StatistiquesForm
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
            lblMoyenne = new Label();
            lblTauxReussite = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblMoyenne
            // 
            lblMoyenne.AutoSize = true;
            lblMoyenne.Location = new Point(43, 54);
            lblMoyenne.Name = "lblMoyenne";
            lblMoyenne.Size = new Size(50, 20);
            lblMoyenne.TabIndex = 0;
            lblMoyenne.Text = "label1";
            // 
            // lblTauxReussite
            // 
            lblTauxReussite.AutoSize = true;
            lblTauxReussite.Location = new Point(43, 111);
            lblTauxReussite.Name = "lblTauxReussite";
            lblTauxReussite.Size = new Size(50, 20);
            lblTauxReussite.TabIndex = 1;
            lblTauxReussite.Text = "label1";
            // 
            // button1
            // 
            button1.Location = new Point(108, 207);
            button1.Name = "button1";
            button1.Size = new Size(145, 31);
            button1.TabIndex = 2;
            button1.Text = "Retour";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StatistiquesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 270);
            Controls.Add(button1);
            Controls.Add(lblTauxReussite);
            Controls.Add(lblMoyenne);
            Name = "StatistiquesForm";
            Text = "StatistiquesForm";
            Load += StatistiquesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMoyenne;
        private Label lblTauxReussite;
        private Button button1;
    }
}