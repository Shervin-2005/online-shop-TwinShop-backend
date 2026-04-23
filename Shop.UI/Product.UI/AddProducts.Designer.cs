namespace Shop.UI.Product.UI
{
    partial class AddProducts
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
            pictureBoxProduct = new PictureBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblCategoryName = new Label();
            txtSecondryPrice = new TextBox();
            lblPriceSecondry = new Label();
            lblBrandName = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtFirstPrice = new TextBox();
            lblPriceInitial = new Label();
            lblChoosenBrand = new Label();
            lblChoosenCategory = new Label();
            btnAdd = new Button();
            txtNumberInStorage = new TextBox();
            lblNumberInStorage = new Label();
            cmbBrandName = new ComboBox();
            cmbCategoryName = new ComboBox();
            btnSelectSideImages = new Button();
            lblSideImagesCount = new Label();
            flowLayoutPanelSideImages = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(12, 12);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(194, 121);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            pictureBoxProduct.Click += pictureBoxProduct_Click;
            pictureBoxProduct.MouseHover += pictureBoxProduct_MouseHover;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(40, 141);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(194, 139);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(197, 27);
            txtProductName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(40, 209);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(113, 20);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category Name";
            // 
            // txtSecondryPrice
            // 
            txtSecondryPrice.Location = new Point(189, 312);
            txtSecondryPrice.Name = "txtSecondryPrice";
            txtSecondryPrice.Size = new Size(202, 27);
            txtSecondryPrice.TabIndex = 6;
            // 
            // lblPriceSecondry
            // 
            lblPriceSecondry.AutoSize = true;
            lblPriceSecondry.Location = new Point(40, 312);
            lblPriceSecondry.Name = "lblPriceSecondry";
            lblPriceSecondry.Size = new Size(106, 20);
            lblPriceSecondry.TabIndex = 5;
            lblPriceSecondry.Text = "Secondry Price";
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(40, 176);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(92, 20);
            lblBrandName.TabIndex = 7;
            lblBrandName.Text = "Brand Name";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(189, 243);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(202, 27);
            txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(40, 243);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Description";
            // 
            // txtFirstPrice
            // 
            txtFirstPrice.Location = new Point(189, 279);
            txtFirstPrice.Name = "txtFirstPrice";
            txtFirstPrice.Size = new Size(202, 27);
            txtFirstPrice.TabIndex = 12;
            // 
            // lblPriceInitial
            // 
            lblPriceInitial.AutoSize = true;
            lblPriceInitial.Location = new Point(40, 276);
            lblPriceInitial.Name = "lblPriceInitial";
            lblPriceInitial.Size = new Size(82, 20);
            lblPriceInitial.TabIndex = 11;
            lblPriceInitial.Text = "Initial Price";
            // 
            // lblChoosenBrand
            // 
            lblChoosenBrand.AutoSize = true;
            lblChoosenBrand.Location = new Point(296, 177);
            lblChoosenBrand.Name = "lblChoosenBrand";
            lblChoosenBrand.Size = new Size(0, 20);
            lblChoosenBrand.TabIndex = 15;
            // 
            // lblChoosenCategory
            // 
            lblChoosenCategory.AutoSize = true;
            lblChoosenCategory.Location = new Point(296, 213);
            lblChoosenCategory.Name = "lblChoosenCategory";
            lblChoosenCategory.Size = new Size(0, 20);
            lblChoosenCategory.TabIndex = 16;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(149, 397);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtNumberInStorage
            // 
            txtNumberInStorage.Location = new Point(189, 351);
            txtNumberInStorage.Name = "txtNumberInStorage";
            txtNumberInStorage.Size = new Size(202, 27);
            txtNumberInStorage.TabIndex = 19;
            // 
            // lblNumberInStorage
            // 
            lblNumberInStorage.AutoSize = true;
            lblNumberInStorage.Location = new Point(38, 355);
            lblNumberInStorage.Name = "lblNumberInStorage";
            lblNumberInStorage.Size = new Size(133, 20);
            lblNumberInStorage.TabIndex = 18;
            lblNumberInStorage.Text = "Number in storage";
            // 
            // cmbBrandName
            // 
            cmbBrandName.FormattingEnabled = true;
            cmbBrandName.Location = new Point(194, 176);
            cmbBrandName.Margin = new Padding(3, 4, 3, 4);
            cmbBrandName.Name = "cmbBrandName";
            cmbBrandName.Size = new Size(195, 28);
            cmbBrandName.TabIndex = 20;
            // 
            // cmbCategoryName
            // 
            cmbCategoryName.FormattingEnabled = true;
            cmbCategoryName.Location = new Point(194, 209);
            cmbCategoryName.Margin = new Padding(3, 4, 3, 4);
            cmbCategoryName.Name = "cmbCategoryName";
            cmbCategoryName.Size = new Size(195, 28);
            cmbCategoryName.TabIndex = 21;
            // 
            // btnSelectSideImages
            // 
            btnSelectSideImages.Location = new Point(445, 12);
            btnSelectSideImages.Name = "btnSelectSideImages";
            btnSelectSideImages.Size = new Size(39, 29);
            btnSelectSideImages.TabIndex = 22;
            btnSelectSideImages.Text = "➕";
            btnSelectSideImages.UseVisualStyleBackColor = true;
            btnSelectSideImages.Click += btnSelectSideImages_Click;
            // 
            // lblSideImagesCount
            // 
            lblSideImagesCount.AutoSize = true;
            lblSideImagesCount.Location = new Point(445, 44);
            lblSideImagesCount.Name = "lblSideImagesCount";
            lblSideImagesCount.Size = new Size(17, 20);
            lblSideImagesCount.TabIndex = 23;
            lblSideImagesCount.Text = "0";
            // 
            // flowLayoutPanelSideImages
            // 
            flowLayoutPanelSideImages.Location = new Point(222, 12);
            flowLayoutPanelSideImages.Name = "flowLayoutPanelSideImages";
            flowLayoutPanelSideImages.Size = new Size(217, 121);
            flowLayoutPanelSideImages.TabIndex = 24;
            // 
            // AddProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 451);
            Controls.Add(flowLayoutPanelSideImages);
            Controls.Add(lblSideImagesCount);
            Controls.Add(btnSelectSideImages);
            Controls.Add(cmbCategoryName);
            Controls.Add(cmbBrandName);
            Controls.Add(txtNumberInStorage);
            Controls.Add(lblNumberInStorage);
            Controls.Add(btnAdd);
            Controls.Add(lblChoosenCategory);
            Controls.Add(lblChoosenBrand);
            Controls.Add(txtFirstPrice);
            Controls.Add(lblPriceInitial);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblBrandName);
            Controls.Add(txtSecondryPrice);
            Controls.Add(lblPriceSecondry);
            Controls.Add(lblCategoryName);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(pictureBoxProduct);
            Name = "AddProducts";
            Text = "AddProducts";
            Load += AddProducts_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxProduct;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategoryName;
        private TextBox txtSecondryPrice;
        private Label lblPriceSecondry;
        private Label lblBrandName;
        private TextBox txtDescription;
        private Label lblDescription;
        private TextBox txtFirstPrice;
        private Label lblPriceInitial;
        private Label lblChoosenBrand;
        private Label lblChoosenCategory;
        private Button btnAdd;
        private TextBox txtNumberInStorage;
        private Label lblNumberInStorage;
        private ComboBox cmbBrandName;
        private ComboBox cmbCategoryName;
        private Button btnSelectSideImages;
        private Label lblSideImagesCount;
        private FlowLayoutPanel flowLayoutPanelSideImages;
    }
}