using Shop.UI.Brand.UI;
using Shop.UI.Category.UI;
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

namespace Shop.UI
{
    public partial class FormBrands : FormStyle
    {
        public FormBrands()
        {
            InitializeComponent();
        }

        private async void FormBrands_Load(object sender, EventArgs e)
        {
            txtSearchBrand.KeyDown += txtSearch_KeyDown!;

            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<BrandViewModel>>>(RouteConstants.GetAllBrands);
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
            LoadBrands(result.Data);
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            FormAddBrand formAddBrand = new FormAddBrand();
            formAddBrand.ShowDialog();
        }
        private void LoadBrands(List<BrandViewModel> brandViewModels)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var brand in brandViewModels)
            {
                var card = new BrandCard();
                card.SetBrand(brand);
                card.Width = 350;
                card.Height = 200;

                card.OnDeleteClicked += Card_OnDeleteClicked!;
                card.OnEditClicked += Card_OnEditClicked!;


                flowLayoutPanel.Controls.Add(card);
            }
        }
        private async void Card_OnDeleteClicked(object sender, BrandViewModel brandViewModel)
        {
            var confirm = MessageBox.Show(
                $"Are you sure to delete'{brandViewModel.BrandName}'?!",
                "Apply Delete?!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.DeleteBrand, brandViewModel.BrandId);
            var result = await client.DeleteAsync<OperationResult>(route);

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }

            var card = sender as BrandCard;
            flowLayoutPanel.Controls.Remove(card);
            card?.Dispose();
        }
        private void Card_OnEditClicked(object sender, BrandViewModel brandViewModel)
        {
            FormEditBrand formEditBrand = new FormEditBrand(brandViewModel);
            formEditBrand.ShowDialog();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _ = LoadSearchResults(txtSearchBrand.Text.Trim());
            }
        }
        private async Task LoadSearchResults(string searchTerm)
        {
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.SearchBrands, searchTerm);
            var result = await client.GetAsync<OperationResult<List<BrandViewModel>>>(route);

            if (result == null || !result.Success)
            {
                ShowInfoError(result?.Message ?? MessagesAndConsts.InternetErrorMessage);
                return;
            }
            var formResults = new FormSearchBrandResult(result.Data);
            formResults.ShowDialog();
        }
    }
    
}
