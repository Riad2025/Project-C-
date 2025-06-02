namespace revisionIsgaG2
{
    partial class EtudiantLoginForm
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
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtNom = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(258, 212);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(176, 43);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(258, 138);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(145, 27);
            txtPassword.TabIndex = 8;
            // 
            // txtNom
            // 
            txtNom.Location = new Point(258, 75);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(145, 27);
            txtNom.TabIndex = 7;
            // 
            // label2
            // 
            label2.AllowDrop = true;
            label2.AutoSize = true;
            label2.Location = new Point(114, 145);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 82);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 5;
            label1.Text = "Username";
            // 
            // button1
            // 
            button1.Location = new Point(67, 212);
            button1.Name = "button1";
            button1.Size = new Size(176, 43);
            button1.TabIndex = 10;
            button1.Text = "Retour menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EtudiantLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 287);
            Controls.Add(button1);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtNom);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EtudiantLoginForm";
            Text = "EtudiantLoginForm";
            Load += EtudiantLoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtNom;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}