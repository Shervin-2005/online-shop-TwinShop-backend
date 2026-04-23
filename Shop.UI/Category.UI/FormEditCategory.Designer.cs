namespace Shop.UI.Category.UI
{
    partial class FormEditCategory
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
            btnSave = new Button();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            pictureBoxCategory = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(72, 213);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(132, 180);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(125, 27);
            txtCategoryName.TabIndex = 1;
            txtCategoryName.TextChanged += textBox1_TextChanged;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(12, 187);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(114, 20);
            lblCategoryName.TabIndex = 2;
            lblCategoryName.Text = "Category  name";
            // 
            // pictureBoxCategory
            // 
            pictureBoxCategory.Location = new Point(29, 12);
            pictureBoxCategory.Name = "pictureBoxCategory";
            pictureBoxCategory.Size = new Size(202, 144);
            pictureBoxCategory.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCategory.TabIndex = 3;
            pictureBoxCategory.TabStop = false;
            pictureBoxCategory.Click += pictureBoxCategory_Click;
            // 
            // FormEditCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 244);
            Controls.Add(pictureBoxCategory);
            Controls.Add(lblCategoryName);
            Controls.Add(txtCategoryName);
            Controls.Add(btnSave);
            Name = "FormEditCategory";
            Text = "FormEditCategory";
            Load += FormEditCategory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtCategoryName;
        private Label lblCategoryName;
        private PictureBox pictureBoxCategory;
    }
}