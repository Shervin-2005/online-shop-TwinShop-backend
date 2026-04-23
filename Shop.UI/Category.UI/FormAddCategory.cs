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
    public partial class FormAddCategory : FormStyle
    {
        string categoryPathImage;
        public FormAddCategory()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            btnAdd.Enabled = false;
            btnAdd.Text = MessagesAndConsts.pleaseWaitText;
            var categoryCardViewModel = new CategoryViewModel()
            {
                MainImage = categoryPathImage,
                CategoryName = txtCategoryName.Text,

            };
            if (!categoryCardViewModel.IsValid)
            {
                ShowInfo(categoryCardViewModel.ErrorMessage);
                btnAdd.Enabled = true;
                btnAdd.Text = MessagesAndConsts.AddText;
                return;
            }

            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, CategoryViewModel>(RouteConstants.CreateCategory, categoryCardViewModel);
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

        private void pictureBoxCategory_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                categoryPathImage = openFileDialog.FileName;
                pictureBoxCategory.ImageLocation = categoryPathImage;
            }
        }

        private void pictureBoxCategory_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBoxCategory, "For choose a profile Please Click");
        }

        private void FormAddCategory_Load(object sender, EventArgs e)
        {
            categoryPathImage=MessagesAndConsts.UplaodImage;
            pictureBoxCategory.ImageLocation = categoryPathImage;
        }
    }
}
