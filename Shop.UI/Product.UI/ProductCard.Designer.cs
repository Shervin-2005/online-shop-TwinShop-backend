namespace Shop.UI.Product.UI
{
    partial class ProductCard
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
            pictureBoxProduct = new PictureBox();
            lblProductName = new Label();
            lblBrand = new Label();
            lblCategory = new Label();
            lblOff = new Label();
            lblPrice = new Label();
            lblNumberInStorage = new Label();
            lblDescription = new Label();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            lblSideImagesCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(37, 4);
            pictureBoxProduct.Margin = new Padding(3, 4, 3, 4);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(114, 103);
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            pictureBoxProduct.Click += pictureBoxProduct_Click;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(30, 148);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(30, 168);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(92, 20);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "Brand Name";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(31, 188);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(113, 20);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category Name";
            lblCategory.Click += lblCategory_Click;
            // 
            // lblOff
            // 
            lblOff.AutoSize = true;
            lblOff.Location = new Point(30, 228);
            lblOff.Name = "lblOff";
            lblOff.Size = new Size(34, 20);
            lblOff.TabIndex = 4;
            lblOff.Text = "OFF";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(30, 248);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // lblNumberInStorage
            // 
            lblNumberInStorage.AutoSize = true;
            lblNumberInStorage.Location = new Point(30, 268);
            lblNumberInStorage.Name = "lblNumberInStorage";
            lblNumberInStorage.Size = new Size(135, 20);
            lblNumberInStorage.TabIndex = 6;
            lblNumberInStorage.Text = "Number In Storage";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(30, 208);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Description";
            // 
            // btnEditProduct
            // 
            btnEditProduct.Location = new Point(157, 43);
            btnEditProduct.Margin = new Padding(3, 4, 3, 4);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(27, 31);
            btnEditProduct.TabIndex = 8;
            btnEditProduct.Text = "✏️";
            btnEditProduct.UseVisualStyleBackColor = true;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(157, 4);
            btnDeleteProduct.Margin = new Padding(3, 4, 3, 4);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(27, 31);
            btnDeleteProduct.TabIndex = 9;
            btnDeleteProduct.Text = "\U0001faa3";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // lblSideImagesCount
            // 
            lblSideImagesCount.AutoSize = true;
            lblSideImagesCount.Location = new Point(65, 128);
            lblSideImagesCount.Name = "lblSideImagesCount";
            lblSideImagesCount.Size = new Size(17, 20);
            lblSideImagesCount.TabIndex = 10;
            lblSideImagesCount.Text = "1";
            // 
            // ProductCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSideImagesCount);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(lblDescription);
            Controls.Add(lblNumberInStorage);
            Controls.Add(lblPrice);
            Controls.Add(lblOff);
            Controls.Add(lblCategory);
            Controls.Add(lblBrand);
            Controls.Add(lblProductName);
            Controls.Add(pictureBoxProduct);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductCard";
            Size = new Size(187, 322);
            Load += lblInitialPrice_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxProduct;
        private Label lblProductName;
        private Label lblBrand;
        private Label lblCategory;
        private Label lblOff;
        private Label lblPrice;
        private Label lblNumberInStorage;
        private Label lblDescription;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
        private Label lblSideImagesCount;
    }
}
