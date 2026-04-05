namespace Shop.UI
{
    partial class FormSignin
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
            lblLogin = new Label();
            txtPassword = new TextBox();
            txtPhone = new TextBox();
            lblPassword = new Label();
            lblPhone = new Label();
            btnSignin = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 8F);
            lblLogin.ForeColor = Color.DodgerBlue;
            lblLogin.Location = new Point(42, 236);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(125, 26);
            lblLogin.TabIndex = 10;
            lblLogin.Text = "don't have an acount?!\r\n sign in now";
            lblLogin.Click += lblLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(41, 160);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(182, 23);
            txtPassword.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(42, 107);
            txtPhone.Margin = new Padding(4, 3, 4, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(182, 23);
            txtPhone.TabIndex = 9;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(42, 136);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "PassWord";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(42, 83);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 15);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Phone Number";
            // 
            // btnSignin
            // 
            btnSignin.Location = new Point(81, 203);
            btnSignin.Margin = new Padding(4, 3, 4, 3);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(89, 31);
            btnSignin.TabIndex = 5;
            btnSignin.Text = "Sign in";
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += btnSignin_Click;
            // 
            // FormSignin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 294);
            Controls.Add(lblLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblPhone);
            Controls.Add(btnSignin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSignin";
            Text = "FormSignin";
            Load += FormSignin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox txtPassword;
        private TextBox txtPhone;
        private Label lblPassword;
        private Label lblPhone;
        private Button btnSignin;
    }
}