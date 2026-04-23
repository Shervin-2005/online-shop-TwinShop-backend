namespace Shop.UI
{
    partial class FormCategories
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
            btnAdd = new Button();
            txtSearch = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(27, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(41, 43);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(75, 47);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search category....";
            txtSearch.Size = new Size(281, 27);
            txtSearch.TabIndex = 4;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(27, 97);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(797, 341);
            flowLayoutPanel.TabIndex = 5;
            // 
            // FormCategories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(846, 451);
            Controls.Add(flowLayoutPanel);
            Controls.Add(txtSearch);
            Controls.Add(btnAdd);
            Name = "FormCategories";
            Text = "FormCategories";
            Load += FormCategories_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private TextBox txtSearch;
        private FlowLayoutPanel flowLayoutPanel;
    }
}