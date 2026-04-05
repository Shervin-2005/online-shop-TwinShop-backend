namespace Shop.UI
{
    partial class FormLogin
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
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblSignin = new Label();
            label1 = new Label();
            lblMessage = new Label();
            lblAllBrands = new Label();
            dataGridView = new DataGridView();
            btnAllBrands = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(57, 243);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(102, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(13, 84);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(116, 21);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone Number";
            lblPhone.Click += lblPhone_Click;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(13, 116);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 29);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 186);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(208, 29);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(13, 154);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "PassWord";
            // 
            // lblSignin
            // 
            lblSignin.AutoSize = true;
            lblSignin.Font = new Font("Segoe UI", 8F);
            lblSignin.ForeColor = Color.DodgerBlue;
            lblSignin.Location = new Point(12, 288);
            lblSignin.Name = "lblSignin";
            lblSignin.Size = new Size(125, 26);
            lblSignin.TabIndex = 4;
            lblSignin.Text = "don't have an acount?!\r\n sign in now";
            lblSignin.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 41);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 5;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 10F);
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.Location = new Point(13, 44);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(45, 19);
            lblMessage.TabIndex = 6;
            lblMessage.Text = "label2";
            // 
            // lblAllBrands
            // 
            lblAllBrands.AutoSize = true;
            lblAllBrands.Location = new Point(731, 27);
            lblAllBrands.Name = "lblAllBrands";
            lblAllBrands.Size = new Size(108, 21);
            lblAllBrands.TabIndex = 7;
            lblAllBrands.Text = "Get All Brands";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(639, 51);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(294, 310);
            dataGridView.TabIndex = 8;
            // 
            // btnAllBrands
            // 
            btnAllBrands.Location = new Point(743, 367);
            btnAllBrands.Name = "btnAllBrands";
            btnAllBrands.Size = new Size(96, 62);
            btnAllBrands.TabIndex = 9;
            btnAllBrands.Text = "Get All Brands";
            btnAllBrands.UseVisualStyleBackColor = true;
            btnAllBrands.Click += btnAllBrands_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(226, 348);
            Controls.Add(btnAllBrands);
            Controls.Add(dataGridView);
            Controls.Add(lblAllBrands);
            Controls.Add(lblMessage);
            Controls.Add(label1);
            Controls.Add(lblSignin);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblPhone);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FormLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Label lblPassword;
        private Label lblSignin;
        private Label label1;
        private Label lblMessage;
        private Label lblAllBrands;
        private DataGridView dataGridView;
        private Button btnAllBrands;
    }
}