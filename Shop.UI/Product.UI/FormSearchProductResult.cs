using Shop.UI.Brand.UI;
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

namespace Shop.UI.Product.UI
{
    public partial class FormSearchProductResult : Form
    {
        private List<ProductCardViewModel> _products;
        public FormSearchProductResult(List<ProductCardViewModel> products)
        {
            InitializeComponent();
            _products = products;
        }
        private void LoadProducts(List<ProductCardViewModel> ProductViewModels)
        {
            flowLayoutPanel.Controls.Clear();

            foreach (var product in ProductViewModels)
            {
                var card = new ProductCard();
                card.SetProduct(product);
                card.Width = 300;
                card.Height = 100;
                flowLayoutPanel.Controls.Add(card);
            }
        }

        private void FormSearchProductResult_Load(object sender, EventArgs e)
        {
            LoadProducts(_products);
        }
    }
}
