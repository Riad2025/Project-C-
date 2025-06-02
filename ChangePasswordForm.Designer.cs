namespace revisionIsgaG2
{
    partial class ChangePasswordForm
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
            label1 = new Label();
            label2 = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 97);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = " New Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 164);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Confirm Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(182, 94);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(157, 27);
            txtNewPassword.TabIndex = 2;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(182, 157);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(157, 27);
            txtConfirmPassword.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(106, 240);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(172, 50);
            btnConfirm.TabIndex = 4;
            btnConfirm.TabStop = false;
            btnConfirm.Text = "Confirmer";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 371);
            Controls.Add(btnConfirm);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ChangePasswordForm";
            Text = "ChangePasswordForm";
            Load += ChangePasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnConfirm;
    }
}