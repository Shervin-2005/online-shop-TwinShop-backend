namespace Shop.UI
{
    partial class FormEditUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditUserInfo));
            lblFirstName = new Label();
            lblLastName = new Label();
            label3 = new Label();
            lblEmail = new Label();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtFirstName = new TextBox();
            ProfilePictureBox = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            btnApply = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnChangePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 12F);
            lblFirstName.Location = new Point(23, 112);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(82, 21);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "FirstName";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 12F);
            lblLastName.Location = new Point(23, 142);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(80, 21);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "LastName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(6, 175);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 2;
            label3.Text = "Phone Number";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F);
            lblEmail.Location = new Point(40, 206);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 21);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Emaill";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(128, 144);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(126, 23);
            txtLastName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(128, 206);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(126, 23);
            txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(128, 173);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(126, 23);
            txtPhone.TabIndex = 9;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(128, 114);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(126, 23);
            txtFirstName.TabIndex = 10;
            // 
            // ProfilePictureBox
            // 
            ProfilePictureBox.Image = (Image)resources.GetObject("ProfilePictureBox.Image");
            ProfilePictureBox.Location = new Point(79, 10);
            ProfilePictureBox.Name = "ProfilePictureBox";
            ProfilePictureBox.Size = new Size(122, 97);
            ProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProfilePictureBox.TabIndex = 12;
            ProfilePictureBox.TabStop = false;
            ProfilePictureBox.LoadCompleted += ProfilePictureBox_LoadCompleted;
            ProfilePictureBox.Click += ProfilePictureBox_Click;
            ProfilePictureBox.MouseHover += ProfilePictureBox_MouseHover;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(136, 259);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 46);
            btnApply.TabIndex = 13;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(128, 235);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(126, 23);
            txtPassword.TabIndex = 17;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F);
            lblPassword.Location = new Point(29, 234);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 21);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(260, 235);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(25, 23);
            btnChangePassword.TabIndex = 18;
            btnChangePassword.Text = "✏️✏";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // FormEditUserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 369);
            Controls.Add(btnChangePassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(btnApply);
            Controls.Add(ProfilePictureBox);
            Controls.Add(txtFirstName);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(lblEmail);
            Controls.Add(label3);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Name = "FormEditUserInfo";
            Text = "FormEditUserInfo";
            Load += FormEditUserInfo_Load;
            ((System.ComponentModel.ISupportInitialize)ProfilePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstName;
        private Label lblLastName;
        private Label label3;
        private Label lblEmail;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtFirstName;
        private PictureBox ProfilePictureBox;
        private OpenFileDialog openFileDialog1;
        private Button btnApply;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnChangePassword;
    }
}