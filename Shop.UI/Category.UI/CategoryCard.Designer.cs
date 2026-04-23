namespace Shop.UI.Category.UI
{
    partial class CategoryCard
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
            pictureBoxCategory = new PictureBox();
            lblCategoryName = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAllProducts = new Button();
            btnAllBrands = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCategory
            // 
            pictureBoxCategory.Location = new Point(28, 17);
            pictureBoxCategory.Margin = new Padding(3, 2, 3, 2);
            pictureBoxCategory.Name = "pictureBoxCategory";
            pictureBoxCategory.Size = new Size(146, 94);
            pictureBoxCategory.TabIndex = 0;
            pictureBoxCategory.TabStop = false;
            pictureBoxCategory.Click += pictureBoxCategory_Click;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(65, 113);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(87, 15);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "CategoryName";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(180, 17);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(35, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "\U0001faa3";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(180, 46);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(35, 23);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "✏️";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAllProducts
            // 
            btnAllProducts.Location = new Point(28, 131);
            btnAllProducts.Name = "btnAllProducts";
            btnAllProducts.Size = new Size(79, 23);
            btnAllProducts.TabIndex = 4;
            btnAllProducts.Text = "All Products";
            btnAllProducts.UseVisualStyleBackColor = true;
            // 
            // btnAllBrands
            // 
            btnAllBrands.Location = new Point(109, 131);
            btnAllBrands.Name = "btnAllBrands";
            btnAllBrands.Size = new Size(82, 23);
            btnAllBrands.TabIndex = 5;
            btnAllBrands.Text = "All Brands";
            btnAllBrands.UseVisualStyleBackColor = true;
            // 
            // CategoryCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAllBrands);
            Controls.Add(btnAllProducts);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(lblCategoryName);
            Controls.Add(pictureBoxCategory);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CategoryCard";
            Size = new Size(220, 173);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCategory;
        private Label lblCategoryName;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAllProducts;
        private Button btnAllBrands;
    }
}
