namespace Shop.UI
{
    partial class FormChangePassword
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
            btnChange = new Button();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            txtRepeatNewPassword = new TextBox();
            lblRepeatNewPassword = new Label();
            SuspendLayout();
            // 
            // btnChange
            // 
            btnChange.Location = new Point(96, 179);
            btnChange.Margin = new Padding(3, 4, 3, 4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(86, 31);
            btnChange.TabIndex = 0;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(14, 53);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(124, 20);
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "Current password";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(147, 49);
            txtCurrentPassword.Margin = new Padding(3, 4, 3, 4);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(114, 27);
            txtCurrentPassword.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(147, 88);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(114, 27);
            txtNewPassword.TabIndex = 4;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(14, 92);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(106, 20);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "New password";
            // 
            // txtRepeatNewPassword
            // 
            txtRepeatNewPassword.Location = new Point(147, 127);
            txtRepeatNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtRepeatNewPassword.Name = "txtRepeatNewPassword";
            txtRepeatNewPassword.Size = new Size(114, 27);
            txtRepeatNewPassword.TabIndex = 6;
            // 
            // lblRepeatNewPassword
            // 
            lblRepeatNewPassword.AutoSize = true;
            lblRepeatNewPassword.Location = new Point(2, 131);
            lblRepeatNewPassword.Name = "lblRepeatNewPassword";
            lblRepeatNewPassword.Size = new Size(154, 20);
            lblRepeatNewPassword.TabIndex = 5;
            lblRepeatNewPassword.Tag = "";
            lblRepeatNewPassword.Text = "Repeat new password";
            // 
            // FormChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 291);
            Controls.Add(txtRepeatNewPassword);
            Controls.Add(lblRepeatNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtCurrentPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(btnChange);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormChangePassword";
            Text = "FormChangePassword";
            Load += FormChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChange;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private TextBox txtNewPassword;
        private Label lblNewPassword;
        private TextBox txtRepeatNewPassword;
        private Label lblRepeatNewPassword;
    }
}