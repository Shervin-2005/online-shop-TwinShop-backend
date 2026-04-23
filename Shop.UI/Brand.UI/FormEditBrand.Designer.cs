namespace Shop.UI.Brand.UI
{
    partial class FormEditBrand
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
            btnSave = new Button();
            cmbCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBrand
            // 
            pictureBoxBrand.Location = new Point(52, 9);
            pictureBoxBrand.Margin = new Padding(3, 2, 3, 2);
            pictureBoxBrand.Name = "pictureBoxBrand";
            pictureBoxBrand.Size = new Size(162, 80);
            pictureBoxBrand.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBrand.TabIndex = 0;
            pictureBoxBrand.TabStop = false;
            pictureBoxBrand.Click += pictureBoxBrand_Click;
            pictureBoxBrand.MouseHover += pictureBoxBrand_MouseHover;
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(10, 101);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(73, 15);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "Brand Name";
            // 
            // txtBrandName
            // 
            txtBrandName.Location = new Point(126, 98);
            txtBrandName.Margin = new Padding(3, 2, 3, 2);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new Size(110, 23);
            txtBrandName.TabIndex = 4;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(10, 128);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(90, 15);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(83, 158);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(126, 125);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(110, 23);
            cmbCategory.TabIndex = 6;
            // 
            // FormEditBrand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 188);
            Controls.Add(cmbCategory);
            Controls.Add(btnSave);
            Controls.Add(txtBrandName);
            Controls.Add(lblCategoryName);
            Controls.Add(lblBrandName);
            Controls.Add(pictureBoxBrand);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormEditBrand";
            Text = "FormEditBrand";
            Load += FormEditBrand_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBrand;
        private Label lblBrandName;
        private TextBox txtBrandName;
        private Label lblCategoryName;
        private Button btnSave;
        private ComboBox cmbCategory;
    }
}