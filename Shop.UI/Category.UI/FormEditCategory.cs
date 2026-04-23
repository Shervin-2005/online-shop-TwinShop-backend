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
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Shop.UI.Category.UI
{
    public partial class FormEditCategory : FormStyle
    {
        string CategoryPathImage;
        private readonly CategoryViewModel _category;
        public FormEditCategory(CategoryViewModel category)
        {
            InitializeComponent();
            _category = category;

        }

        private void FormEditCategory_Load(object sender, EventArgs e)
        {
            txtCategoryName.Text = _category.CategoryName;
            CategoryPathImage = _category.MainImage!;
            pictureBoxCategory.ImageLocation = CategoryPathImage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxCategory_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CategoryPathImage = openFileDialog.FileName;
                pictureBoxCategory.ImageLocation = CategoryPathImage;
            }
        }
        private void pictureBoxCategory_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBoxCategory, "For choose a profile Please Click");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Text=MessagesAndConsts.pleaseWaitText;
            var categoryCardViewModel = new CategoryViewModel()
            {
                CategoryId = _category.CategoryId,
               CategoryName=txtCategoryName.Text,
               MainImage=CategoryPathImage,
            };
            if (!categoryCardViewModel.IsValid)
            {
                ShowInfo(categoryCardViewModel.ErrorMessage);
                btnSave.Enabled = true;
                btnSave.Text = MessagesAndConsts.SaveText;
                return;
            }
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.UpdateCategory, categoryCardViewModel.CategoryId);
            var result =await client.PostAsync<OperationResult,CategoryViewModel>(route, categoryCardViewModel);
            if(result == null)
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
