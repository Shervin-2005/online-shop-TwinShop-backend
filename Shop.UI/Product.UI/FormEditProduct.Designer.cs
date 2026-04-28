namespace Shop.UI.Product.UI
{
    partial class FormEditProduct
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
            cmbCategoryName = new ComboBox();
            cmbBrandName = new ComboBox();
            txtNumberInStorage = new TextBox();
            lblNumberInStorage = new Label();
            btnSave = new Button();
            lblChoosenCategory = new Label();
            lblChoosenBrand = new Label();
            txtFirstPrice = new TextBox();
            lblPriceInitial = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblBrandName = new Label();
            txtSecondryPrice = new TextBox();
            lblPriceSecondry = new Label();
            lblCategoryName = new Label();
            txtProductName = new TextBox();
            lblProductName = new Label();
            pictureBoxProduct = new PictureBox();
            flowLayoutPanelSideImages = new FlowLayoutPanel();
            btnAddSideImage = new Button();
            lblSideImagesCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            // 
            // cmbCategoryName
            // 
            cmbCategoryName.FormattingEnabled = true;
            cmbCategoryName.Location = new Point(187, 212);
            cmbCategoryName.Margin = new Padding(3, 4, 3, 4);
            cmbCategoryName.Name = "cmbCategoryName";
            cmbCategoryName.Size = new Size(195, 28);
            cmbCategoryName.TabIndex = 39;
            // 
            // cmbBrandName
            // 
            cmbBrandName.FormattingEnabled = true;
            cmbBrandName.Location = new Point(187, 179);
            cmbBrandName.Margin = new Padding(3, 4, 3, 4);
            cmbBrandName.Name = "cmbBrandName";
            cmbBrandName.Size = new Size(195, 28);
            cmbBrandName.TabIndex = 38;
            // 
            // txtNumberInStorage
            // 
            txtNumberInStorage.Location = new Point(182, 353);
            txtNumberInStorage.Name = "txtNumberInStorage";
            txtNumberInStorage.Size = new Size(202, 27);
            txtNumberInStorage.TabIndex = 37;
            // 
            // lblNumberInStorage
            // 
            lblNumberInStorage.AutoSize = true;
            lblNumberInStorage.Location = new Point(31, 357);
            lblNumberInStorage.Name = "lblNumberInStorage";
            lblNumberInStorage.Size = new Size(133, 20);
            lblNumberInStorage.TabIndex = 36;
            lblNumberInStorage.Text = "Number in storage";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(142, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 35;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblChoosenCategory
            // 
            lblChoosenCategory.AutoSize = true;
            lblChoosenCategory.Location = new Point(289, 216);
            lblChoosenCategory.Name = "lblChoosenCategory";
            lblChoosenCategory.Size = new Size(0, 20);
            lblChoosenCategory.TabIndex = 34;
            // 
            // lblChoosenBrand
            // 
            lblChoosenBrand.AutoSize = true;
            lblChoosenBrand.Location = new Point(289, 180);
            lblChoosenBrand.Name = "lblChoosenBrand";
            lblChoosenBrand.Size = new Size(0, 20);
            lblChoosenBrand.TabIndex = 33;
            // 
            // txtFirstPrice
            // 
            txtFirstPrice.Location = new Point(182, 281);
            txtFirstPrice.Name = "txtFirstPrice";
            txtFirstPrice.Size = new Size(202, 27);
            txtFirstPrice.TabIndex = 32;
            // 
            // lblPriceInitial
            // 
            lblPriceInitial.AutoSize = true;
            lblPriceInitial.Location = new Point(33, 279);
            lblPriceInitial.Name = "lblPriceInitial";
            lblPriceInitial.Size = new Size(82, 20);
            lblPriceInitial.TabIndex = 31;
            lblPriceInitial.Text = "Initial Price";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(182, 245);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(202, 27);
            txtDescription.TabIndex = 30;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(33, 245);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 29;
            lblDescription.Text = "Description";
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(33, 179);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(92, 20);
            lblBrandName.TabIndex = 28;
            lblBrandName.Text = "Brand Name";
            // 
            // txtSecondryPrice
            // 
            txtSecondryPrice.Location = new Point(182, 315);
            txtSecondryPrice.Name = "txtSecondryPrice";
            txtSecondryPrice.Size = new Size(202, 27);
            txtSecondryPrice.TabIndex = 27;
            // 
            // lblPriceSecondry
            // 
            lblPriceSecondry.AutoSize = true;
            lblPriceSecondry.Location = new Point(33, 315);
            lblPriceSecondry.Name = "lblPriceSecondry";
            lblPriceSecondry.Size = new Size(106, 20);
            lblPriceSecondry.TabIndex = 26;
            lblPriceSecondry.Text = "Secondry Price";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(33, 212);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(113, 20);
            lblCategoryName.TabIndex = 25;
            lblCategoryName.Text = "Category Name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(187, 141);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(197, 27);
            txtProductName.TabIndex = 24;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(33, 144);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 20);
            lblProductName.TabIndex = 23;
            lblProductName.Text = "Product Name";
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(14, 15);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(194, 117);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduct.TabIndex = 22;
            pictureBoxProduct.TabStop = false;
            pictureBoxProduct.Click += pictureBoxProduct_Click;
            pictureBoxProduct.MouseHover += pictureBoxProduct_MouseHover;
            // 
            // flowLayoutPanelSideImages
            // 
            flowLayoutPanelSideImages.AutoScroll = true;
            flowLayoutPanelSideImages.Location = new Point(231, 15);
            flowLayoutPanelSideImages.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelSideImages.Name = "flowLayoutPanelSideImages";
            flowLayoutPanelSideImages.Size = new Size(215, 117);
            flowLayoutPanelSideImages.TabIndex = 40;
            // 
            // btnAddSideImage
            // 
            btnAddSideImage.Location = new Point(453, 15);
            btnAddSideImage.Margin = new Padding(3, 4, 3, 4);
            btnAddSideImage.Name = "btnAddSideImage";
            btnAddSideImage.Size = new Size(31, 31);
            btnAddSideImage.TabIndex = 41;
            btnAddSideImage.Text = "➕";
            btnAddSideImage.UseVisualStyleBackColor = true;
            btnAddSideImage.Click += btnAddSideImage_Click;
            // 
            // lblSideImagesCount
            // 
            lblSideImagesCount.AutoSize = true;
            lblSideImagesCount.Location = new Point(458, 56);
            lblSideImagesCount.Name = "lblSideImagesCount";
            lblSideImagesCount.Size = new Size(17, 20);
            lblSideImagesCount.TabIndex = 42;
            lblSideImagesCount.Text = "0";
            // 
            // FormEditProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 433);
            Controls.Add(lblSideImagesCount);
            Controls.Add(btnAddSideImage);
            Controls.Add(flowLayoutPanelSideImages);
            Controls.Add(cmbCategoryName);
            Controls.Add(cmbBrandName);
            Controls.Add(txtNumberInStorage);
            Controls.Add(lblNumberInStorage);
            Controls.Add(btnSave);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEditProduct";
            Text = "FormEditProduct";
            Load += FormEditProduct_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategoryName;
        private ComboBox cmbBrandName;
        private TextBox txtNumberInStorage;
        private Label lblNumberInStorage;
        private Button btnSave;
        private Label lblChoosenCategory;
        private Label lblChoosenBrand;
        private TextBox txtFirstPrice;
        private Label lblPriceInitial;
        private TextBox txtDescription;
        private Label lblDescription;
        private Label lblBrandName;
        private TextBox txtSecondryPrice;
        private Label lblPriceSecondry;
        private Label lblCategoryName;
        private TextBox txtProductName;
        private Label lblProductName;
        private PictureBox pictureBoxProduct;
        private FlowLayoutPanel flowLayoutPanelSideImages;
        private Button btnAddSideImage;
        private Label lblSideImagesCount;
    }
}