namespace Shop.UI.Brand.UI
{
    partial class BrandCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxBrand = new PictureBox();
            lblBrandName = new Label();
            lblCategoryName = new Label();
            btnAllProducts = new Button();
            btnDeleteBrand = new Button();
            btnEditBrand = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxBrand
            // 
            pictureBoxBrand.Location = new Point(12, 11);
            pictureBoxBrand.Margin = new Padding(3, 2, 3, 2);
            pictureBoxBrand.Name = "pictureBoxBrand";
            pictureBoxBrand.Size = new Size(156, 88);
            pictureBoxBrand.TabIndex = 0;
            pictureBoxBrand.TabStop = false;
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(61, 119);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(73, 15);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "Brand Name";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(44, 134);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(90, 15);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category Name";
            // 
            // btnAllProducts
            // 
            btnAllProducts.Location = new Point(39, 151);
            btnAllProducts.Margin = new Padding(3, 2, 3, 2);
            btnAllProducts.Name = "btnAllProducts";
            btnAllProducts.Size = new Size(105, 22);
            btnAllProducts.TabIndex = 5;
            btnAllProducts.Text = "All Products";
            btnAllProducts.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBrand
            // 
            btnDeleteBrand.Location = new Point(3, 151);
            btnDeleteBrand.Margin = new Padding(3, 2, 3, 2);
            btnDeleteBrand.Name = "btnDeleteBrand";
            btnDeleteBrand.Size = new Size(38, 22);
            btnDeleteBrand.TabIndex = 6;
            btnDeleteBrand.Text = "\U0001faa3";
            btnDeleteBrand.UseVisualStyleBackColor = true;
            btnDeleteBrand.Click += btnDeleteBrand_Click;
            // 
            // btnEditBrand
            // 
            btnEditBrand.Location = new Point(150, 151);
            btnEditBrand.Margin = new Padding(3, 2, 3, 2);
            btnEditBrand.Name = "btnEditBrand";
            btnEditBrand.Size = new Size(27, 22);
            btnEditBrand.TabIndex = 7;
            btnEditBrand.Text = "✏️";
            btnEditBrand.UseVisualStyleBackColor = true;
            btnEditBrand.Click += btnEditBrand_Click;
            // 
            // BrandCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEditBrand);
            Controls.Add(btnDeleteBrand);
            Controls.Add(btnAllProducts);
            Controls.Add(lblCategoryName);
            Controls.Add(lblBrandName);
            Controls.Add(pictureBoxBrand);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BrandCard";
            Size = new Size(182, 186);
            Load += BrandCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrand).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxBrand;
        private Label lblBrandName;
        private Label lblCategoryName;
        private Button btnAllProducts;
        private Button btnDeleteBrand;
        private Button btnEditBrand;
    }
}
