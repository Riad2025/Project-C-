namespace revisionIsgaG2
{
    partial class PublicationResultatsForm
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
            lblTotal = new Label();
            lblValides = new Label();
            lblNonValides = new Label();
            lblPublies = new Label();
            btnPublier = new Button();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(61, 63);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "label2";
            // 
            // lblValides
            // 
            lblValides.AutoSize = true;
            lblValides.Location = new Point(198, 63);
            lblValides.Name = "lblValides";
            lblValides.Size = new Size(50, 20);
            lblValides.TabIndex = 2;
            lblValides.Text = "label3";
            // 
            // lblNonValides
            // 
            lblNonValides.AutoSize = true;
            lblNonValides.Location = new Point(343, 63);
            lblNonValides.Name = "lblNonValides";
            lblNonValides.Size = new Size(50, 20);
            lblNonValides.TabIndex = 3;
            lblNonValides.Text = "label4";
            // 
            // lblPublies
            // 
            lblPublies.AutoSize = true;
            lblPublies.Location = new Point(485, 63);
            lblPublies.Name = "lblPublies";
            lblPublies.Size = new Size(50, 20);
            lblPublies.TabIndex = 4;
            lblPublies.Text = "label5";
            // 
            // btnPublier
            // 
            btnPublier.Location = new Point(198, 562);
            btnPublier.Name = "btnPublier";
            btnPublier.Size = new Size(200, 56);
            btnPublier.TabIndex = 5;
            btnPublier.Text = "Publier";
            btnPublier.UseVisualStyleBackColor = true;
            btnPublier.Click += btnPublier_Click;
            // 
            // PublicationResultatsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 639);
            Controls.Add(btnPublier);
            Controls.Add(lblPublies);
            Controls.Add(lblNonValides);
            Controls.Add(lblValides);
            Controls.Add(lblTotal);
            Name = "PublicationResultatsForm";
            Text = "PublicationResultatsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTotal;
        private Label lblValides;
        private Label lblNonValides;
        private Label lblPublies;
        private Button btnPublier;
    }
}