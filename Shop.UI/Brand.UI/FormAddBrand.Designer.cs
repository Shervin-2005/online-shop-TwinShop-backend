namespace Shop.UI.Brand.UI
{
    partial class FormAddBrand
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
            pictureBoxBrand = new PictureBox();
            lblBrandName = new Label();
            txtBrandName = new TextBox();
            lblCategoryName = new Label();
            btnAdd = new Button();
            cmbCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBrand
            // 
            pictureBoxBrand.Location = new Point(74, 12);
            pictureBoxBrand.Name = "pictureBoxBrand";
            pictureBoxBrand.Size = new Size(154, 104);
            pictureBoxBrand.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBrand.TabIndex = 0;
            pictureBoxBrand.TabStop = false;
            pictureBoxBrand.Click += pictureBoxBrand_Click;
            pictureBoxBrand.MouseHover += pictureBoxBrand_MouseHover;
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(20, 136);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(92, 20);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "Brand Name";
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(139, 129);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(125, 27);
            txtBrandName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(20, 169);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(113, 20);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category Name";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(102, 210);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(139, 161);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(125, 28);
            cmbCategory.TabIndex = 6;
            // 
            // FormAddBrand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 260);
            Controls.Add(cmbCategory);
            Controls.Add(btnAdd);
            Controls.Add(lblCategoryName);
            Controls.Add(txtBrandName);
            Controls.Add(lblBrandName);
            Controls.Add(pictureBoxBrand);
            Name = "FormAddBrand";
            Text = "FormAddBrand";
            Load += FormAddBrand_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBrand;
        private Label lblBrandName;
        private TextBox txtBrandName;
        private Label lblCategoryName;
        private Button btnAdd;
        private ComboBox cmbCategory;
    }
}