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
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            // 
            // cmbCategoryName
            // 
            cmbCategoryName.FormattingEnabled = true;
            cmbCategoryName.Location = new Point(164, 159);
            cmbCategoryName.Name = "cmbCategoryName";
            cmbCategoryName.Size = new Size(171, 23);
            cmbCategoryName.TabIndex = 39;
            // 
            // cmbBrandName
            // 
            cmbBrandName.FormattingEnabled = true;
            cmbBrandName.Location = new Point(164, 134);
            cmbBrandName.Name = "cmbBrandName";
            cmbBrandName.Size = new Size(171, 23);
            cmbBrandName.TabIndex = 38;
            // 
            // txtNumberInStorage
            // 
            txtNumberInStorage.Location = new Point(159, 265);
            txtNumberInStorage.Margin = new Padding(3, 2, 3, 2);
            txtNumberInStorage.Name = "txtNumberInStorage";
            txtNumberInStorage.Size = new Size(177, 23);
            txtNumberInStorage.TabIndex = 37;
            // 
            // lblNumberInStorage
            // 
            lblNumberInStorage.AutoSize = true;
            lblNumberInStorage.Location = new Point(27, 268);
            lblNumberInStorage.Name = "lblNumberInStorage";
            lblNumberInStorage.Size = new Size(106, 15);
            lblNumberInStorage.TabIndex = 36;
            lblNumberInStorage.Text = "Number in storage";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(124, 300);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 22);
            btnSave.TabIndex = 35;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblChoosenCategory
            // 
            lblChoosenCategory.AutoSize = true;
            lblChoosenCategory.Location = new Point(253, 162);
            lblChoosenCategory.Name = "lblChoosenCategory";
            lblChoosenCategory.Size = new Size(0, 15);
            lblChoosenCategory.TabIndex = 34;
            // 
            // lblChoosenBrand
            // 
            lblChoosenBrand.AutoSize = true;
            lblChoosenBrand.Location = new Point(253, 135);
            lblChoosenBrand.Name = "lblChoosenBrand";
            lblChoosenBrand.Size = new Size(0, 15);
            lblChoosenBrand.TabIndex = 33;
            // 
            // txtFirstPrice
            // 
            txtFirstPrice.Location = new Point(159, 211);
            txtFirstPrice.Margin = new Padding(3, 2, 3, 2);
            txtFirstPrice.Name = "txtFirstPrice";
            txtFirstPrice.Size = new Size(177, 23);
            txtFirstPrice.TabIndex = 32;
            // 
            // lblPriceInitial
            // 
            lblPriceInitial.AutoSize = true;
            lblPriceInitial.Location = new Point(29, 209);
            lblPriceInitial.Name = "lblPriceInitial";
            lblPriceInitial.Size = new Size(65, 15);
            lblPriceInitial.TabIndex = 31;
            lblPriceInitial.Text = "Initial Price";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(159, 184);
            txtDescription.Margin = new Padding(3, 2, 3, 2);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(177, 23);
            txtDescription.TabIndex = 30;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(29, 184);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 29;
            lblDescription.Text = "Description";
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Location = new Point(29, 134);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(73, 15);
            lblBrandName.TabIndex = 28;
            lblBrandName.Text = "Brand Name";
            // 
            // txtSecondryPrice
            // 
            txtSecondryPrice.Location = new Point(159, 236);
            txtSecondryPrice.Margin = new Padding(3, 2, 3, 2);
            txtSecondryPrice.Name = "txtSecondryPrice";
            txtSecondryPrice.Size = new Size(177, 23);
            txtSecondryPrice.TabIndex = 27;
            // 
            // lblPriceSecondry
            // 
            lblPriceSecondry.AutoSize = true;
            lblPriceSecondry.Location = new Point(29, 236);
            lblPriceSecondry.Name = "lblPriceSecondry";
            lblPriceSecondry.Size = new Size(85, 15);
            lblPriceSecondry.TabIndex = 26;
            lblPriceSecondry.Text = "Secondry Price";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(29, 159);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(90, 15);
            lblCategoryName.TabIndex = 25;
            lblCategoryName.Text = "Category Name";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(164, 106);
            txtProductName.Margin = new Padding(3, 2, 3, 2);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(173, 23);
            txtProductName.TabIndex = 24;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(29, 108);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 23;
            lblProductName.Text = "Product Name";
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.Location = new Point(82, 11);
            pictureBoxProduct.Margin = new Padding(3, 2, 3, 2);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(170, 88);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduct.TabIndex = 22;
            pictureBoxProduct.TabStop = false;
            pictureBoxProduct.Click += pictureBoxProduct_Click;
            pictureBoxProduct.MouseHover += pictureBoxProduct_MouseHover;
            // 
            // FormEditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 332);
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
    }
}