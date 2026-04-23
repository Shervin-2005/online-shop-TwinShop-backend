using Shop.UI.Brand.UI;
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

namespace Shop.UI
{
    public partial class FormProducts : FormStyle
    {
        public FormProducts()
        {
            InitializeComponent();
        }

       

        private async void FormProducts_Load(object sender, EventArgs e)
        {
            txtSearchProduct.KeyDown += txtSearch_KeyDown!;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<ProductCardViewModel>>>(RouteConstants.GetAllProducts);
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
            LoadProducts(result.Data);
        }
        private void LoadProducts(List<ProductCardViewModel> productCardViewModelList)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var product in productCardViewModelList)
            {
                var card = new ProductCard();
                card.SetProduct(product);
                card.Width = 200;
                card.Height = 280;

                card.OnDeleteClicked += Card_OnDeleteClicked!;
                card.OnEditClicked += Card_OnEditClicked!;

                flowLayoutPanel.Controls.Add(card);
            }
        }
        private async void Card_OnDeleteClicked(object sender, ProductCardViewModel productViewModel)
        {
            var confirm = MessageBox.Show(
                $"Are you sure to delete'{productViewModel.ProductName}'?!",
                "Apply Delete?!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.DeleteProduct, productViewModel.ProductId);
            var result = await client.DeleteAsync<OperationResult>(route);

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }

            var card = sender as ProductCard;
            flowLayoutPanel.Controls.Remove(card);
            card?.Dispose();
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
           AddProducts addProducts = new AddProducts();
           addProducts.ShowDialog();
        }
        private void Card_OnEditClicked(object sender, ProductCardViewModel productViewModel)
        {
            FormEditProduct formEditProduct = new FormEditProduct(productViewModel);
            formEditProduct.ShowDialog();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = LoadSearchResults(txtSearchProduct.Text.Trim());
            }
        }
        private async Task LoadSearchResults(string searchTerm)
        {
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.SearchProducts, searchTerm);
            var result = await client.GetAsync<OperationResult<List<ProductCardViewModel>>>(route);

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }
            var formResults = new FormSearchProductResult(result.Data);
            formResults.ShowDialog();
        }
    }
}
