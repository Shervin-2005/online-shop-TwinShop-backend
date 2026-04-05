using Shop.UI.Http;
using Twin_Shop__Web_API.DTOs.Brand;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels;

namespace Shop.UI
{
    public partial class FormLogin : FormStyle
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnLogin.Text = Messages.pleaseWaitText;
            UserViewModel user = new UserViewModel
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text
            };
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, UserViewModel>(RouteConstants.LoginRoute, user);
            
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }
            if (result.Success)
            {
                ShowInfo(result.Message!);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }
            CurrentUser.PhoneNumber = txtPhone.Text;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //var result = await _client.GetAsync<List<BrandDto>>(RouteConstants.GetBrandAll);
            //if (result == null || result.Count == 0)
            //{
            //    MessageBox.Show("برندی وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = result;
            //}
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSignin_Click(object sender, EventArgs e)
        {
            //UserDto registerDto = new UserDto()
            //{
            //    PhoneNumber = txtPhone.Text,
            //    PasswordHash = txtPassword.Text,
            //    Email = txtEmail.Text
            //};
            //var result = await _client.PostAsync<bool, UserDto>(RouteConstants.RegisterRoute, registerDto);
            //if (result == true)
            //{
            //    MessageBox.Show("welcome");
            //}
            //else
            //{
            //    MessageBox.Show("اطلاعات درست نیست");
            //}
        }

        private async void btnGetUserByPhone_Click(object sender, EventArgs e)
        {
            //string phoneNumber = txtPhone.Text;
            //var url = $"{RouteConstants.GetbyPhoneNumber}?phoneNumber={phoneNumber}";
            //var result = await _client.GetAsync<UserDto>(url);
            //if (result == null)
            //{
            //    MessageBox.Show(" وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = new List<UserDto> { result };
            //}

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnGetUserByEmail_Click(object sender, EventArgs e)
        {
            //string email = txtEmail.Text;
            //var url = $"{RouteConstants.GetbyEmail}?email={email}";
            //var result = await _client.GetAsync<UserDto>(url);
            //if (result == null)
            //{
            //    MessageBox.Show(" وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = new List<UserDto> { result };
            //}
        }

        private async void btnGetBrandById_Click(object sender, EventArgs e)
        {

            //int id = int.Parse(txtNameOrId.Text);
            //var url = $"{RouteConstants.GetById}?id={id}";
            //var result = await _client.GetAsync<BrandDto>(url);
            //if (result == null)
            //{
            //    MessageBox.Show("برندی وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = new List<BrandDto> { result };
            //}
        }

        private async void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(txtNameOrId.Text);
            //var url = $"{RouteConstants.Delete}?id={id}";
            //var result = await _client.DeleteAsync(url);
            //if (result)
            //{
            //    MessageBox.Show("Brand has been deleted!");
            //}
            //else
            //{
            //    MessageBox.Show("Brand has not been deleted or its not here!");
            //}
        }

        private async void btnGetBrandByName_Click(object sender, EventArgs e)
        {
            //string name = txtNameOrId.Text;
            //var url = $"{RouteConstants.GetBrandsByName}?name={name}";
            //var result = await _client.GetAsync<List<BrandDto>>(url);
            //if (result == null)
            //{
            //    MessageBox.Show("برندی وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = result;
            //}
        }

        private async void btnGetBrandByCategoryName_Click(object sender, EventArgs e)
        {
            //string categoryName = txtNameOrId.Text;
            //var url = $"{RouteConstants.GetBrandsByCategoryName}?categoryName={categoryName}";
            //var result = await _client.GetAsync<List<BrandDto>>(url);
            //if (result == null)
            //{
            //    MessageBox.Show("برندی وجود ندارد");
            //}
            //else
            //{
            //    dataGridView.DataSource = result;
            //}
        }

        private async void btnCreateBrand_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateBrand_Click(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormSignin formSignin = new FormSignin();
            formSignin.Show();
            this.Hide();
        }

        private async void btnAllBrands_Click(object sender, EventArgs e)
        {
            //var result = await _client.GetAsync<List<BrandDto>>(RouteConstants.GetBrandAll);
            //if (result == null || result.Count == 0)
            //{
            //    MessageBox.Show("There is no brands to show!");
            //}
            //else
            //{
            //    dataGridView.DataSource = result;
            //}
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

