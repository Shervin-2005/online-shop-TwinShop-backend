namespace Shop.UI.User.UI
{
    partial class LoginWithCode
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
            lblSignin = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            btnSendCode = new Button();
            lblLoginWithPass = new Label();
            SuspendLayout();
            // 
            // lblSignin
            // 
            lblSignin.AutoSize = true;
            lblSignin.Font = new Font("Segoe UI", 8F);
            lblSignin.ForeColor = Color.DodgerBlue;
            lblSignin.Location = new Point(26, 130);
            lblSignin.Name = "lblSignin";
            lblSignin.Size = new Size(125, 26);
            lblSignin.TabIndex = 11;
            lblSignin.Text = "don't have an acount?!\r\n sign in now";
            lblSignin.Click += lblSignin_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(27, 41);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 23);
            txtPhone.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(27, 22);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 15);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Phone Number";
            // 
            // btnSendCode
            // 
            btnSendCode.Location = new Point(78, 85);
            btnSendCode.Margin = new Padding(4);
            btnSendCode.Name = "btnSendCode";
            btnSendCode.Size = new Size(102, 41);
            btnSendCode.TabIndex = 6;
            btnSendCode.Text = "Send Code";
            btnSendCode.UseVisualStyleBackColor = true;
            btnSendCode.Click += btnEnter_Click;
            // 
            // lblLoginWithPass
            // 
            lblLoginWithPass.AutoSize = true;
            lblLoginWithPass.Font = new Font("Segoe UI", 8F);
            lblLoginWithPass.ForeColor = Color.DodgerBlue;
            lblLoginWithPass.Location = new Point(26, 68);
            lblLoginWithPass.Name = "lblLoginWithPass";
            lblLoginWithPass.Size = new Size(115, 13);
            lblLoginWithPass.TabIndex = 12;
            lblLoginWithPass.Text = "Login with password";
            lblLoginWithPass.Click += lblLoginWithPass_Click;
            // 
            // LoginWithCode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 171);
            Controls.Add(lblLoginWithPass);
            Controls.Add(lblSignin);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(btnSendCode);
            Name = "LoginWithCode";
            Text = "LoginWithCode";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSignin;
        private TextBox txtPhone;
        private Label lblPhone;
        private Button btnSendCode;
        private Label lblLoginWithPass;
    }
}