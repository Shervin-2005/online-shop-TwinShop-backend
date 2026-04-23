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

namespace Shop.UI.Product.UI
{
    public partial class AddProducts : FormStyle
    {

        string productPathImage;
        private List<string> selectedSideImages = new List<string>();
        public AddProducts()
        {
            InitializeComponent();
        }
        private async Task LoadCategoriesAsync()
        {
            cmbCategoryName.Enabled = false;
            cmbCategoryName.Items.Add("Loading...");
            cmbCategoryName.SelectedIndex = 0;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<CategoryViewModel>>>(RouteConstants.GetAllCategories);

            cmbCategoryName.Items.Clear();

            if (result == null || !result.Success)
            {
                ShowInfoError(MessagesAndConsts.ErrorGetingCategories);
                cmbCategoryName.Enabled = true;
                return;
            }

            cmbCategoryName.DisplayMember = "CategoryName";
            cmbCategoryName.ValueMember = "CategoryName";
            cmbCategoryName.DataSource = result.Data;
            cmbCategoryName.SelectedIndex = -1;
            cmbCategoryName.Enabled = true;
        }
        private async Task LoadBrandsAsync()
        {
            cmbBrandName.Enabled = false;
            cmbBrandName.Items.Add("Loading...");
            cmbBrandName.SelectedIndex = 0;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<BrandViewModel>>>(RouteConstants.GetAllBrands);

            cmbBrandName.Items.Clear();

            if (result == null || !result.Success)
            {
                ShowInfoError(MessagesAndConsts.ErrorGetingBrands);
                cmbBrandName.Enabled = true;
                return;
            }

            cmbBrandName.DisplayMember = "BrandName";
            cmbBrandName.ValueMember = "BrandName";
            cmbBrandName.DataSource = result.Data;
            cmbBrandName.SelectedIndex = -1;
            cmbBrandName.Enabled = true;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (cmbCategoryName.SelectedItem == null)
            {
                ShowInfo("pls select a category!");
                return;
            }
            if (cmbBrandName.SelectedItem == null)
            {
                ShowInfo("pls select a Brand!");
                return;
            }
            btnAdd.Enabled = false;
            btnAdd.Text = MessagesAndConsts.pleaseWaitText;

            var selectedCategory = (CategoryViewModel)cmbCategoryName.SelectedItem;
            var selectedBrand = (BrandViewModel)cmbBrandName.SelectedItem;

            var productViewModel = new ProductCardViewModel()
            {
                MainImageUrl = productPathImage,
                ProductName = txtProductName.Text,
                BrandName = selectedBrand.BrandName,
                CategoryName = selectedCategory.CategoryName,
                Description = txtDescription.Text,
                InitialPrice = int.Parse(txtFirstPrice.Text),
                SecondryPrice = int.Parse(txtSecondryPrice.Text),
                NumberInStorage = int.Parse(txtNumberInStorage.Text),
                SideImageUrls = selectedSideImages,
            };
            if (!productViewModel.IsValid)
            {
                ShowInfo(productViewModel.ErrorMessage);
                btnAdd.Enabled = true;
                btnAdd.Text = MessagesAndConsts.AddText;
                return;
            }

            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, ProductCardViewModel>(RouteConstants.CreateProduct, productViewModel);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnAdd.Enabled = true;
                btnAdd.Text = MessagesAndConsts.AddText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnAdd.Enabled = true;
                btnAdd.Text = MessagesAndConsts.AddText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            productPathImage = MessagesAndConsts.UplaodImage;
            pictureBoxProduct.ImageLocation = productPathImage;
            LoadCategoriesAsync();
            LoadBrandsAsync();
        }

        private void pictureBoxProduct_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBoxProduct, "For choose a profile Please Click");
        }

        private void pictureBoxProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                productPathImage = openFileDialog.FileName;
                pictureBoxProduct.ImageLocation = productPathImage;
            }
        }

        private void btnSelectSideImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select Side Images";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedSideImages.Clear();
                selectedSideImages.AddRange(openFileDialog.FileNames);

                lblSideImagesCount.Text = $"{selectedSideImages.Count} images selected";

                ShowSideImagesPreviews();
            }
        }
        private void ShowSideImagesPreviews()
        {
            flowLayoutPanelSideImages.Controls.Clear();

            foreach (var imagePath in selectedSideImages)
            {
                PictureBox pb = new PictureBox
                {
                    Width = 80,
                    Height = 80,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(imagePath),
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };
                flowLayoutPanelSideImages.Controls.Add(pb);
            }
        }
    }
}
