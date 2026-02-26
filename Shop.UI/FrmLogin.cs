
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.DTOs.Brand;


namespace Shop.UI
{
    public partial class FrmLogin : Form
    {
        private readonly HttpClientHelper _client;
        public FrmLogin(HttpClientHelper client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            
            LoginDto loginDto = new LoginDto()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
            };
            var result = await _client.PostAsync<bool, LoginDto>(RouteConstants.LoginRoute, loginDto);
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
            var result = await _client.GetAsync<List<BrandDto>>(RouteConstants.GetBrandAll);
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                dataGridBrands.DataSource = result;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
