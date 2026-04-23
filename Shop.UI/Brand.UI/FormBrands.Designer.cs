namespace Shop.UI
{
    partial class FormBrands
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
            btnAddBrand = new Button();
            txtSearchBrand = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnAddBrand
            // 
            btnAddBrand.Location = new Point(25, 9);
            btnAddBrand.Margin = new Padding(3, 2, 3, 2);
            btnAddBrand.Name = "btnAddBrand";
            btnAddBrand.Size = new Size(30, 22);
            btnAddBrand.TabIndex = 0;
            btnAddBrand.Text = "+";
            btnAddBrand.UseVisualStyleBackColor = true;
            btnAddBrand.Click += btnAddBrand_Click;
            // 
            // txtSearchBrand
            // 
            txtSearchBrand.Location = new Point(60, 9);
            txtSearchBrand.Margin = new Padding(3, 2, 3, 2);
            txtSearchBrand.Name = "txtSearchBrand";
            txtSearchBrand.PlaceholderText = "Search brand.....";
            txtSearchBrand.Size = new Size(331, 23);
            txtSearchBrand.TabIndex = 1;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(10, 45);
            flowLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(1027, 590);
            flowLayoutPanel.TabIndex = 2;
            // 
            // FormBrands
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 646);
            Controls.Add(flowLayoutPanel);
            Controls.Add(txtSearchBrand);
            Controls.Add(btnAddBrand);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormBrands";
            Text = "FormBrands";
            Load += FormBrands_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddBrand;
        private TextBox txtSearchBrand;
        private FlowLayoutPanel flowLayoutPanel;
    }
}