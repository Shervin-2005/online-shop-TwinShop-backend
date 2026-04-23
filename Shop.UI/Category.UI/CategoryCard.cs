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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shop.UI.Category.UI
{
    public partial class CategoryCard : UserControl
    {
        private CategoryViewModel _category;
        public event EventHandler<CategoryViewModel> OnDeleteClicked;
        public event EventHandler<CategoryViewModel> OnEditClicked;
        public CategoryCard()
        {
            InitializeComponent();
        }
        public void SetCategory(CategoryViewModel categoryCardViewModel)
        {
            _category = categoryCardViewModel;

            pictureBoxCategory.ImageLocation = categoryCardViewModel.MainImage;
            pictureBoxCategory.SizeMode = PictureBoxSizeMode.Zoom;

            lblCategoryName.Text = categoryCardViewModel.CategoryName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked?.Invoke(this, _category);
        }

        private void pictureBoxCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, _category);
        }
    }
}
