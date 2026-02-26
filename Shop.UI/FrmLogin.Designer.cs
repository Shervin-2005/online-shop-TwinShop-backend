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
            button1 = new Button();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            btnAllBrands = new Button();
            dataGridBrands = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridBrands).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(274, 214);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(129, 41);
            button1.TabIndex = 0;
            button1.Text = "btnLogin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(469, 81);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(39, 21);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "تلفن";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(226, 75);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 29);
            txtPhone.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(226, 117);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(208, 29);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(456, 120);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 21);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "پسورد";
            // 
            // btnAllBrands
            // 
            btnAllBrands.Location = new Point(87, 185);
            btnAllBrands.Margin = new Padding(4);
            btnAllBrands.Name = "btnAllBrands";
            btnAllBrands.Size = new Size(129, 41);
            btnAllBrands.TabIndex = 0;
            btnAllBrands.Text = "All Brands";
            btnAllBrands.UseVisualStyleBackColor = true;
            btnAllBrands.Click += button2_Click;
            // 
            // dataGridBrands
            // 
            dataGridBrands.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBrands.Location = new Point(456, 165);
            dataGridBrands.Name = "dataGridBrands";
            dataGridBrands.Size = new Size(240, 150);
            dataGridBrands.TabIndex = 3;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 369);
            Controls.Add(dataGridBrands);
            Controls.Add(txtPassword);
            Controls.Add(txtPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblPhone);
            Controls.Add(btnAllBrands);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FrmLogin";
            Text = "FrmLogin";
            ((System.ComponentModel.ISupportInitialize)dataGridBrands).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Label lblPassword;
        private Button btnAllBrands;
        private DataGridView dataGridBrands;
    }
}