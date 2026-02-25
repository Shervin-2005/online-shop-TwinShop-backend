namespace Shop.UI
{
    partial class FrmLogin
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
            btnAllBrands = new Button();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            dataGridShowBrands = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridShowBrands).BeginInit();
            SuspendLayout();
            // 
            // btnAllBrands
            // 
            btnAllBrands.Location = new Point(-4, 165);
            btnAllBrands.Margin = new Padding(4);
            btnAllBrands.Name = "btnAllBrands";
            btnAllBrands.Size = new Size(246, 41);
            btnAllBrands.TabIndex = 0;
            btnAllBrands.Text = " Show All Brands";
            btnAllBrands.UseVisualStyleBackColor = true;
            btnAllBrands.Click += button1_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(456, 39);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(39, 21);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "تلفن";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(226, 31);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 29);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(226, 68);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(208, 29);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(445, 76);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "پسورد";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(305, 115);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(129, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button2_Click;
            // 
            // dataGridShowBrands
            // 
            dataGridShowBrands.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridShowBrands.Location = new Point(456, 139);
            dataGridShowBrands.Name = "dataGridShowBrands";
            dataGridShowBrands.Size = new Size(240, 150);
            dataGridShowBrands.TabIndex = 3;
            dataGridShowBrands.CellContentClick += dataGridShowBrands_CellContentClick;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 369);
            Controls.Add(dataGridShowBrands);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblPhone);
            Controls.Add(btnLogin);
            Controls.Add(btnAllBrands);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)dataGridShowBrands).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAllBrands;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnLogin;
        private DataGridView dataGridShowBrands;
    }
}