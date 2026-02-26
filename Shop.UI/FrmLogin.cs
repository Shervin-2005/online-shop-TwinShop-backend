
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.DTOs.Brand;
using TwinShop.Shared.DTOS.Auth;


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
                dataGridView.DataSource = result;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSignin_Click(object sender, EventArgs e)
        {
            RegisterDto registerDto = new RegisterDto()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text
            };
            var result = await _client.PostAsync<bool, RegisterDto>(RouteConstants.RegisterRoute, registerDto);
            if (result == true)
            {
                MessageBox.Show("welcome");
            }
            else
            {
                MessageBox.Show("اطلاعات درست نیست");
            }
        }

        private async void btnGetUserByPhone_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhone.Text;
            var url = $"{RouteConstants.GetbyPhoneNumber}?phoneNumber={phoneNumber}";
            var result = await _client.GetAsync<UserDto>(url);
            if (result == null)
            {
                MessageBox.Show(" وجود ندارد");
            }
            else
            {
                dataGridView.DataSource = new List<UserDto> { result };
            }

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnGetUserByEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            var url = $"{RouteConstants.GetbyEmail}?email={email}";
            var result = await _client.GetAsync<UserDto>(url);
            if (result == null)
            {
                MessageBox.Show(" وجود ندارد");
            }
            else
            {
                dataGridView.DataSource = new List<UserDto> { result };
            }
        }

        private async void btnGetBrandById_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtNameOrId.Text);
            var url = $"{RouteConstants.GetById}?id={id}";
            var result = await _client.GetAsync<BrandDto>(url);
            if (result == null)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                dataGridView.DataSource = new List<BrandDto> { result };
            }
        }

        private async void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtNameOrId.Text);
            var url = $"{RouteConstants.Delete}?id={id}";
            var result = await _client.DeleteAsync(url);
            if (result)
            {
                MessageBox.Show("Brand has been deleted!");
            }
            else
            {
                MessageBox.Show("Brand has not been deleted or its not here!");
            }
        }

        private async void btnGetBrandByName_Click(object sender, EventArgs e)
        {
            string name = txtNameOrId.Text;
            var url = $"{RouteConstants.GetBrandsByName}?name={name}";
            var result = await _client.GetAsync<List<BrandDto>>(url);
            if (result == null)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                dataGridView.DataSource = result;
            }
        }

        private async void btnGetBrandByCategoryName_Click(object sender, EventArgs e)
        {
            string categoryName = txtNameOrId.Text;
            var url = $"{RouteConstants.GetBrandsByCategoryName}?categoryName={categoryName}";
            var result = await _client.GetAsync<List<BrandDto>>(url);
            if (result == null)
            {
                MessageBox.Show("برندی وجود ندارد");
            }
            else
            {
                dataGridView.DataSource = result;
            }
        }

        private async void btnCreateBrand_Click(object sender, EventArgs e)
        {
            
        }
    }
}

