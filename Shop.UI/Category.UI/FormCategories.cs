using Shop.UI.Category.UI;
using Shop.UI.Http;
using Shop.UI.Product.UI;
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

namespace Shop.UI
{
    public partial class FormCategories : FormStyle
    {
        public FormCategories()
        {
            InitializeComponent();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private async void FormCategories_Load(object sender, EventArgs e)
        {
            txtSearch.KeyDown += txtSearch_KeyDown!;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<CategoryViewModel>>>(RouteConstants.GetAllCategories);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                return;
            }
            LoadCategories(result.Data);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory = new FormAddCategory();
            formAddCategory.ShowDialog();
        }
        private void LoadCategories(List<CategoryViewModel> categoryCardViewModels)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var category in categoryCardViewModels)
            {
                var card = new CategoryCard();
                card.SetCategory(category);
                card.Width = 300;
                card.Height = 180;

                card.OnDeleteClicked += Card_OnDeleteClicked!;
                card.OnEditClicked += Card_OnEditClicked!;


                flowLayoutPanel.Controls.Add(card);
            }
        }
        private async void Card_OnDeleteClicked(object sender, CategoryViewModel categoryCardViewModel)
        {
            var confirm = MessageBox.Show(
                $"Are you sure to delete'{categoryCardViewModel.CategoryName}'?!",
                "Apply Delete?!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.DeleteCategory, categoryCardViewModel.CategoryId);
            var result = await client.DeleteAsync<OperationResult>(
                route
            );

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }

            var card = sender as CategoryCard;
            flowLayoutPanel.Controls.Remove(card);
            card?.Dispose();
        }
        private void Card_OnEditClicked(object sender, CategoryViewModel categoryCardViewModel)
        {
            FormEditCategory formEditCategory = new FormEditCategory(categoryCardViewModel);
            formEditCategory.ShowDialog();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = LoadSearchResults(txtSearch.Text.Trim());
            }
        }
        private async Task LoadSearchResults(string searchTerm)
        {
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.SearchCategories, searchTerm);
            var result = await client.GetAsync<OperationResult<List<CategoryViewModel>>>(route);

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }
            var formResults = new FormSearchCategoryResult(result.Data);
            formResults.ShowDialog();
        }
    }
}
