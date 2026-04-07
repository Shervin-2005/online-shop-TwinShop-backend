namespace Shop.UI
{
    partial class FormAdmin
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
            btnProduct = new Button();
            btnBrand = new Button();
            btnCategory = new Button();
            btnUsers = new Button();
            SuspendLayout();
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(113, 169);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(75, 50);
            btnProduct.TabIndex = 0;
            btnProduct.Text = "Products";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnBrand
            // 
            btnBrand.Location = new Point(272, 169);
            btnBrand.Name = "btnBrand";
            btnBrand.Size = new Size(75, 50);
            btnBrand.TabIndex = 1;
            btnBrand.Text = "Brands";
            btnBrand.UseVisualStyleBackColor = true;
            btnBrand.Click += btnBrand_Click;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(427, 169);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(75, 50);
            btnCategory.TabIndex = 2;
            btnCategory.Text = "Categories";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(590, 169);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(75, 50);
            btnUsers.TabIndex = 3;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 398);
            Controls.Add(btnUsers);
            Controls.Add(btnCategory);
            Controls.Add(btnBrand);
            Controls.Add(btnProduct);
            Name = "FormAdmin";
            Text = "Admin";
            ResumeLayout(false);
        }

        #endregion

        private Button btnProduct;
        private Button btnBrand;
        private Button btnCategory;
        private Button btnUsers;
    }
}