using Shop.UI.Http;
using System.Threading.Tasks.Dataflow;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace Shop.UI.Brand.UI
{
    public partial class FormAddBrand : FormStyle
    {
        string brandPathImage;
        public FormAddBrand()
        {
            InitializeComponent();
        }
        private void FormAddBrand_Load_1(object sender, EventArgs e)
        {
            brandPathImage = MessagesAndConsts.UplaodImage;
            pictureBoxBrand.ImageLocation = brandPathImage;

            LoadCategoriesAsync();
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

        private void pictureBoxBrand_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBoxBrand, "For choose a profile Please Click");
        }
        private void pictureBoxBrand_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                brandPathImage = openFileDialog.FileName;
                pictureBoxBrand.ImageLocation = brandPathImage;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                ShowInfo("pls select a category!");
                return;
            }
            btnAdd.Enabled = false;
            btnAdd.Text = MessagesAndConsts.pleaseWaitText;

            var selectedCategory = (CategoryViewModel)cmbCategory.SelectedItem;

            var brandViewModel = new BrandViewModel()
            {
                MainImage = brandPathImage,
                BrandName = txtBrandName.Text,
                CategoryName = selectedCategory.CategoryName,

            };
            if (!brandViewModel.IsValid)
            {
                ShowInfo(brandViewModel.ErrorMessage);
                btnAdd.Enabled = true;
                btnAdd.Text = MessagesAndConsts.AddText;
                return;
            }

            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, BrandViewModel>(RouteConstants.CreateBrand, brandViewModel);
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
    }
}
