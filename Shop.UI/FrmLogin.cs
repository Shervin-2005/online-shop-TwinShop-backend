using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.DTOs.Brand;

namespace Shop.UI
{
    public partial class FrmLogin : Form
    {
        private readonly HttpClient _client = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            var clientHelper = new HttpClientHelper(_client);
            LoginDto loginDto = new LoginDto()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
            };
            var result = await clientHelper.PostAsync<bool, LoginDto>(RouteConstants.LoginRoute, loginDto);
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

            var clientHelper = new HttpClientHelper(_client);
            var result = await clientHelper.GetAsync<BrandDto>(string.Format(RouteConstants.GetBrandAll));
            if (result == null)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                dataGridShowBrands.DataSource= result;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridShowBrands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
