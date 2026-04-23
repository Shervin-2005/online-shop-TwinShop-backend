using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinShop.Shared.ViewModels;

namespace Shop.UI.Product.UI
{
    public partial class FormProductSideImages : Form
    {
        private ProductCardViewModel _product;
        private int currentIndex = 0;
        public FormProductSideImages(ProductCardViewModel product)
        {
            InitializeComponent();
            _product = product;
        }

        private void FormProductSideImages_Load(object sender, EventArgs e)
        {
            ShowImage(_product.MainImageUrl!);
            LoadSideThumbnails();
        }
        private void LoadSideThumbnails()
        {
            flowLayoutPanelThumbnails.Controls.Clear();

            AddThumbnail(_product.MainImageUrl!, -1);

            for (int i = 0; i < _product.SideImageUrls!.Count; i++)
            {
                AddThumbnail(_product.SideImageUrls[i], i);
            }
        }
        private void AddThumbnail(string imageUrl, int index)
        {
            PictureBox pb = new PictureBox
            {
                Width = 60,
                Height = 60,
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(5),
                Cursor = Cursors.Hand,
                Tag = index
            };

            pb.LoadAsync(imageUrl);
            pb.Click += Thumbnail_Click;

            flowLayoutPanelThumbnails.Controls.Add(pb);
        }
        private void Thumbnail_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            int index = (int)pb.Tag;

            if (index == -1)
                ShowImage(_product.MainImageUrl!);
            else
                ShowImage(_product.SideImageUrls![index]);
        }
        private void ShowImage(string imageUrl)
        {
            pictureBoxMainImage.LoadAsync(imageUrl);
        }
    }
}
