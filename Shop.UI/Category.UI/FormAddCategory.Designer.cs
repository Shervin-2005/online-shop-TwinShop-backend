namespace Shop.UI.Category.UI
{
    partial class FormAddCategory
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
            pictureBoxCategory = new PictureBox();
            btnAdd = new Button();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCategory
            // 
            pictureBoxCategory.Location = new Point(76, 12);
            pictureBoxCategory.Name = "pictureBoxCategory";
            pictureBoxCategory.Size = new Size(152, 99);
            pictureBoxCategory.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCategory.TabIndex = 0;
            pictureBoxCategory.TabStop = false;
            pictureBoxCategory.Click += pictureBoxCategory_Click;
            pictureBoxCategory.MouseHover += pictureBoxCategory_MouseHover;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(103, 157);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(37, 123);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(113, 20);
            lblCategoryName.TabIndex = 2;
            lblCategoryName.Text = "Category Name";
            lblCategoryName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(174, 120);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(97, 27);
            txtCategoryName.TabIndex = 3;
            // 
            // FormAddCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 206);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(btnAdd);
            Controls.Add(pictureBoxCategory);
            Name = "FormAddCategory";
            Text = "FormAddCategory";
            Load += FormAddCategory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCategory;
        private Button btnAdd;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
    }
}