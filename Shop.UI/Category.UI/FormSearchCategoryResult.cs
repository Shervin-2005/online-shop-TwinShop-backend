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

namespace Shop.UI.Category.UI
{
    public partial class FormSearchCategoryResult : Form
    {
        private List<CategoryViewModel> _categories;
        public FormSearchCategoryResult(List<CategoryViewModel>categories)
        {
            InitializeComponent();
            _categories = categories;
        }

        private void FormSearchResult_Load(object sender, EventArgs e)
        {
            LoadCategories(_categories);
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
                flowLayoutPanel.Controls.Add(card);
            }
        }
    }
}
