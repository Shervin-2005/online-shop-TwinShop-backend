using Shop.UI.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace Shop.UI.Brand.UI
{
    public partial class FormEditBrand : FormStyle
    {
        string BrandPathImage;
        private readonly BrandViewModel _brand;
        public FormEditBrand(BrandViewModel brand)
        {
            InitializeComponent();
            _brand = brand;
        }
        private async Task LoadCategoriesAsync()
        {
            cmbCategory.Enabled = false;
            cmbCategory.Items.Add("Loading...");
            cmbCategory.SelectedIndex = 0;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<CategoryViewModel>>>(RouteConstants.GetAllCategories);

            cmbCategory.Items.Clear();

            if (result == null || !result.Success)
            {
                ShowInfoError(MessagesAndConsts.ErrorGetingCategories);
                cmbCategory.Enabled = true;
                return;
            }

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryName";
            cmbCategory.DataSource = result.Data;
            cmbCategory.SelectedIndex = -1;
            cmbCategory.Enabled = true;
        }
        private async void FormEditBrand_Load(object sender, EventArgs e)
        {
            txtBrandName.Text = _brand.BrandName;
            BrandPathImage = _brand.MainImage!;
            pictureBoxBrand.ImageLocation = BrandPathImage;
            LoadCategoriesAsync();
        }

        private void pictureBoxBrand_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BrandPathImage = openFileDialog.FileName;
                pictureBoxBrand.ImageLocation = BrandPathImage;
            }
        }

        private void pictureBoxBrand_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBoxBrand, "For choose a profile Please Click");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                ShowInfo("pls select a category!");
                return;
            }
            btnSave.Enabled = false;
            btnSave.Text = MessagesAndConsts.pleaseWaitText;

            var selectedCategory = (CategoryViewModel)cmbCategory.SelectedItem;

            var brandViewModel = new BrandViewModel()
            {
                BrandId = _brand.BrandId,
                BrandName = txtBrandName.Text,
                CategoryName = selectedCategory.CategoryName,
                MainImage = BrandPathImage,
            };
            if (!brandViewModel.IsValid)
            {
                ShowInfo(brandViewModel.ErrorMessage);
                btnSave.Enabled = true;
                btnSave.Text = MessagesAndConsts.SaveText;
                return;
            }
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.UpdateBrand, brandViewModel.BrandId);
            var result = await client.PostAsync<OperationResult, BrandViewModel>(route, brandViewModel);
            if (result == null)
            {
                ShowInfo(MessagesAndConsts.InternetErrorMessage);
                btnSave.Enabled = true;
                btnSave.Text = MessagesAndConsts.SaveText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnSave.Enabled = true;
                btnSave.Text = MessagesAndConsts.SaveText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
        }
    }
}
