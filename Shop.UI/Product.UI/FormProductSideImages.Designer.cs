namespace Shop.UI.Product.UI
{
    partial class FormProductSideImages
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
            pictureBoxMainImage = new PictureBox();
            flowLayoutPanelThumbnails = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMainImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMainImage
            // 
            pictureBoxMainImage.Location = new Point(292, 12);
            pictureBoxMainImage.Name = "pictureBoxMainImage";
            pictureBoxMainImage.Size = new Size(186, 131);
            pictureBoxMainImage.TabIndex = 0;
            pictureBoxMainImage.TabStop = false;
            // 
            // flowLayoutPanelThumbnails
            // 
            flowLayoutPanelThumbnails.Location = new Point(9, 149);
            flowLayoutPanelThumbnails.Name = "flowLayoutPanelThumbnails";
            flowLayoutPanelThumbnails.Size = new Size(779, 289);
            flowLayoutPanelThumbnails.TabIndex = 1;
            // 
            // FormProductSideImages
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelThumbnails);
            Controls.Add(pictureBoxMainImage);
            Name = "FormProductSideImages";
            Text = "FormProductSideImages";
            Load += FormProductSideImages_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMainImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMainImage;
        private FlowLayoutPanel flowLayoutPanelThumbnails;
    }
}