namespace Shop.UI
{
    partial class FormProducts
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
            btnAddProduct = new Button();
            txtSearchProduct = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(12, 48);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(52, 38);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "+";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(79, 57);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.PlaceholderText = "Search Product....";
            txtSearchProduct.Size = new Size(390, 23);
            txtSearchProduct.TabIndex = 3;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(12, 92);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(960, 458);
            flowLayoutPanel.TabIndex = 7;
            // 
            // FormProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(984, 562);
            Controls.Add(flowLayoutPanel);
            Controls.Add(txtSearchProduct);
            Controls.Add(btnAddProduct);
            Name = "FormProducts";
            Text = "FormProducts";
            Load += FormProducts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAddProduct;
        private TextBox txtSearchProduct;
        private FlowLayoutPanel flowLayoutPanel;
    }
}