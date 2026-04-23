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
    public partial class FormSearchBrandResult : Form
    {
        private List<BrandViewModel> _brands;
        public FormSearchBrandResult(List<BrandViewModel> brands)
        {
            InitializeComponent();
            _brands = brands;
        }

        private void FormSearchBrandResult_Load(object sender, EventArgs e)
        {
            LoadBrands(_brands);
        }
        private void LoadBrands(List<BrandViewModel> brandViewModels)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var brand in brandViewModels)
            {
                var card = new BrandCard();
                card.SetBrand(brand);
                card.Width = 300;
                card.Height = 100;
                flowLayoutPanel.Controls.Add(card);
            }
        }
    }
}
