using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.UI.Http;

namespace Shop.UI
{
    public partial class FormSignin : Form
    {
        private readonly HttpClientHelper _client;

        public FormSignin(HttpClientHelper client)
        {
            InitializeComponent();
            _client = client;
        }
        public FormSignin()
        {
            InitializeComponent();
        }


        private void lblLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            this.Hide();
            login.Show();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {

        }
    }
}
