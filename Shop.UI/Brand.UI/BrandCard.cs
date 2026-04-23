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

namespace Shop.UI.Brand.UI
{
    public partial class BrandCard : UserControl
    {
        private BrandViewModel _brand;
        public event EventHandler<BrandViewModel> OnDeleteClicked;
        public event EventHandler<BrandViewModel> OnEditClicked;
        public BrandCard()
        {
            InitializeComponent();
        }
        public void SetBrand(BrandViewModel brandViewModel)
        {
            _brand = brandViewModel;

            pictureBoxBrand.ImageLocation = brandViewModel.MainImage;
            pictureBoxBrand.SizeMode = PictureBoxSizeMode.Zoom;

            lblCategoryName.Text = brandViewModel.CategoryName;
            lblBrandName.Text = brandViewModel.BrandName;
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            OnDeleteClicked?.Invoke(this, _brand);
        }

        private void btnEditBrand_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, _brand);
        }

        private void BrandCard_Load(object sender, EventArgs e)
        {

        }
    }
}
