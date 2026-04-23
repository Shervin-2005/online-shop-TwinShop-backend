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
    public partial class ProductCard : UserControl
    {
        private ProductCardViewModel _product;
        public event EventHandler<ProductCardViewModel> OnDeleteClicked;
        public event EventHandler<ProductCardViewModel> OnEditClicked;
        public ProductCard()
        {
            InitializeComponent();
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void lblInitialPrice_Load(object sender, EventArgs e)
        {
        }
        public void SetProduct(ProductCardViewModel productCardViewModel)
        {
            _product = productCardViewModel;

            pictureBoxProduct.ImageLocation = productCardViewModel.MainImageUrl;
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;

            lblProductName.Text = productCardViewModel.ProductName;
            lblBrand.Text = productCardViewModel.BrandName;
            lblCategory.Text = productCardViewModel.CategoryName;
            lblPrice.Text = $"{productCardViewModel.SecondryPrice} dollors";
            lblDescription.Text = productCardViewModel.Description;
            int OFF = productCardViewModel.InitialPrice / productCardViewModel.SecondryPrice;
            lblOff.Text = $"{100 - OFF}%";
            lblNumberInStorage.Text = $"{productCardViewModel.NumberInStorage.ToString()} numbers";

            if (productCardViewModel.SideImageUrls != null && productCardViewModel.SideImageUrls.Any())
            {
                lblSideImagesCount.Text = $"📷 {productCardViewModel.SideImageUrls.Count}";
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            OnDeleteClicked?.Invoke(this, _product);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, _product);
        }

        private void pictureBoxProduct_Click(object sender, EventArgs e)
        {
            if (_product.SideImageUrls != null && _product.SideImageUrls.Any())
            {
                FormProductSideImages gallery = new FormProductSideImages(_product);
                gallery.ShowDialog();
            
            }
        }
    }
}
