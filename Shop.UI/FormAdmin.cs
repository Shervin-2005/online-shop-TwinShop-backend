using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.UI
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormProducts products = new FormProducts();
            products.ShowDialog();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            FormBrands brands = new FormBrands();
            brands.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FormCategories categories = new FormCategories();
            categories.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormUsers users = new FormUsers();
            users.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormEditUserInfo editUserInfo=new FormEditUserInfo();
            editUserInfo.ShowDialog();
        }
    }
}
