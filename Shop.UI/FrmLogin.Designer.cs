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
            btnLogin = new Button();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnAllBrands = new Button();
            dataGridView = new DataGridView();
            btnSignin = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            btnGetUserByPhone = new Button();
            btnGetUserByEmail = new Button();
            btnGetBrandById = new Button();
            btnDeleteBrand = new Button();
            btnGetBrandsByName = new Button();
            btnGetBrandByCategoryName = new Button();
            btnUpdateBrand = new Button();
            btnCreateBrand = new Button();
            lblNameOrId = new Label();
            txtNameOrId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(989, 145);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(86, 41);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(1232, 16);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(54, 21);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(989, 10);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 29);
            txtPhone.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(989, 52);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(208, 29);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(1219, 55);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(78, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "PassWord";
            // 
            // btnAllBrands
            // 
            btnAllBrands.Location = new Point(1, 6);
            btnAllBrands.Margin = new Padding(4);
            btnAllBrands.Name = "btnAllBrands";
            btnAllBrands.Size = new Size(94, 52);
            btnAllBrands.TabIndex = 0;
            btnAllBrands.Text = "All Brands";
            btnAllBrands.UseVisualStyleBackColor = true;
            btnAllBrands.Click += button2_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(649, 256);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(618, 186);
            dataGridView.TabIndex = 3;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // btnSignin
            // 
            btnSignin.Location = new Point(1095, 145);
            btnSignin.Margin = new Padding(4);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(86, 41);
            btnSignin.TabIndex = 4;
            btnSignin.Text = "Sign In";
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += btnSignin_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(989, 89);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(208, 29);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(1219, 92);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(48, 21);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // btnGetUserByPhone
            // 
            btnGetUserByPhone.Location = new Point(989, 194);
            btnGetUserByPhone.Margin = new Padding(4);
            btnGetUserByPhone.Name = "btnGetUserByPhone";
            btnGetUserByPhone.Size = new Size(102, 55);
            btnGetUserByPhone.TabIndex = 7;
            btnGetUserByPhone.Text = "Find With Phone";
            btnGetUserByPhone.UseVisualStyleBackColor = true;
            btnGetUserByPhone.Click += btnGetUserByPhone_Click;
            // 
            // btnGetUserByEmail
            // 
            btnGetUserByEmail.Location = new Point(1095, 194);
            btnGetUserByEmail.Margin = new Padding(4);
            btnGetUserByEmail.Name = "btnGetUserByEmail";
            btnGetUserByEmail.Size = new Size(102, 55);
            btnGetUserByEmail.TabIndex = 8;
            btnGetUserByEmail.Text = "Find With Email";
            btnGetUserByEmail.UseVisualStyleBackColor = true;
            btnGetUserByEmail.Click += btnGetUserByEmail_Click;
            // 
            // btnGetBrandById
            // 
            btnGetBrandById.Location = new Point(103, 6);
            btnGetBrandById.Margin = new Padding(4);
            btnGetBrandById.Name = "btnGetBrandById";
            btnGetBrandById.Size = new Size(94, 52);
            btnGetBrandById.TabIndex = 9;
            btnGetBrandById.Text = "Get Brand By ID";
            btnGetBrandById.UseVisualStyleBackColor = true;
            btnGetBrandById.Click += btnGetBrandById_Click;
            // 
            // btnDeleteBrand
            // 
            btnDeleteBrand.Location = new Point(205, 6);
            btnDeleteBrand.Margin = new Padding(4);
            btnDeleteBrand.Name = "btnDeleteBrand";
            btnDeleteBrand.Size = new Size(94, 52);
            btnDeleteBrand.TabIndex = 10;
            btnDeleteBrand.Text = "Delete Brand";
            btnDeleteBrand.UseVisualStyleBackColor = true;
            btnDeleteBrand.Click += btnDeleteBrand_Click;
            // 
            // btnGetBrandsByName
            // 
            btnGetBrandsByName.Location = new Point(307, 6);
            btnGetBrandsByName.Margin = new Padding(4);
            btnGetBrandsByName.Name = "btnGetBrandsByName";
            btnGetBrandsByName.Size = new Size(94, 52);
            btnGetBrandsByName.TabIndex = 11;
            btnGetBrandsByName.Text = "Get Brands By Name";
            btnGetBrandsByName.UseVisualStyleBackColor = true;
            btnGetBrandsByName.Click += btnGetBrandByName_Click;
            // 
            // btnGetBrandByCategoryName
            // 
            btnGetBrandByCategoryName.Location = new Point(409, 6);
            btnGetBrandByCategoryName.Margin = new Padding(4);
            btnGetBrandByCategoryName.Name = "btnGetBrandByCategoryName";
            btnGetBrandByCategoryName.Size = new Size(131, 52);
            btnGetBrandByCategoryName.TabIndex = 12;
            btnGetBrandByCategoryName.Text = "Get Brand By Category Name";
            btnGetBrandByCategoryName.UseVisualStyleBackColor = true;
            btnGetBrandByCategoryName.Click += btnGetBrandByCategoryName_Click;
            // 
            // btnUpdateBrand
            // 
            btnUpdateBrand.Location = new Point(548, 6);
            btnUpdateBrand.Margin = new Padding(4);
            btnUpdateBrand.Name = "btnUpdateBrand";
            btnUpdateBrand.Size = new Size(94, 52);
            btnUpdateBrand.TabIndex = 13;
            btnUpdateBrand.Text = "Update Brand";
            btnUpdateBrand.UseVisualStyleBackColor = true;
            // 
            // btnCreateBrand
            // 
            btnCreateBrand.Location = new Point(650, 6);
            btnCreateBrand.Margin = new Padding(4);
            btnCreateBrand.Name = "btnCreateBrand";
            btnCreateBrand.Size = new Size(94, 52);
            btnCreateBrand.TabIndex = 14;
            btnCreateBrand.Text = "Create Brand";
            btnCreateBrand.UseVisualStyleBackColor = true;
            btnCreateBrand.Click += btnCreateBrand_Click;
            // 
            // lblNameOrId
            // 
            lblNameOrId.AutoSize = true;
            lblNameOrId.Location = new Point(1174, 465);
            lblNameOrId.Margin = new Padding(4, 0, 4, 0);
            lblNameOrId.Name = "lblNameOrId";
            lblNameOrId.Size = new Size(93, 21);
            lblNameOrId.TabIndex = 15;
            lblNameOrId.Text = "Name Or ID";
            // 
            // txtNameOrId
            // 
            txtNameOrId.Location = new Point(1044, 462);
            txtNameOrId.Margin = new Padding(4);
            txtNameOrId.Name = "txtNameOrId";
            txtNameOrId.Size = new Size(122, 29);
            txtNameOrId.TabIndex = 16;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 537);
            Controls.Add(txtNameOrId);
            Controls.Add(lblNameOrId);
            Controls.Add(btnCreateBrand);
            Controls.Add(btnUpdateBrand);
            Controls.Add(btnGetBrandByCategoryName);
            Controls.Add(btnGetBrandsByName);
            Controls.Add(btnDeleteBrand);
            Controls.Add(btnGetBrandById);
            Controls.Add(btnGetUserByEmail);
            Controls.Add(btnGetUserByPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(btnSignin);
            Controls.Add(dataGridView);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblPhone);
            Controls.Add(btnAllBrands);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FrmLogin";
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
        private Button btnAllBrands;
        private DataGridView dataGridView;
        private Button btnSignin;
        private TextBox txtEmail;
        private Label lblEmail;
        private Button btnGetUserByPhone;
        private Button btnGetUserByEmail;
        private Button btnGetBrandById;
        private Button btnDeleteBrand;
        private Button btnGetBrandsByName;
        private Button btnGetBrandByCategoryName;
        private Button btnUpdateBrand;
        private Button btnCreateBrand;
        private Label lblNameOrId;
        private TextBox txtNameOrId;
    }
}