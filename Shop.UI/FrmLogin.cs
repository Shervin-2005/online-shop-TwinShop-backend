using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.DTOs.Brand;


namespace Shop.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClientHelper();
            LoginDto loginDto = new LoginDto()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
            };
            var result = await client.PostAsync<bool, LoginDto>(RouteConstants.LoginRoute, loginDto);
            if (result == true)
            {
                MessageBox.Show("welcome");
            }
            else
            {
                MessageBox.Show("اطلاعات درست نیست");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var client = new HttpClientHelper();
            var result = await client.GetAsync<BrandDto>(string.Format(RouteConstants.GetBrandById, txtPhone.Text));
            if (result == null)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                MessageBox.Show(result.BrandName);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
