using Shop.UI.Http;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
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
            btnLogin.Text = MessagesAndConsts.pleaseWaitText;
            UserViewModel userViewModel = new UserViewModel
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text
            };
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult<UserViewModel>, UserViewModel>(RouteConstants.LoginRoute, userViewModel);
            if (!userViewModel.IsValid)
            {
                ShowInfo(userViewModel.ErrorMessage);
                btnLogin.Enabled = true;
                btnLogin.Text = MessagesAndConsts.SingUpText;
                return;
            }
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnLogin.Enabled = true;
                btnLogin.Text = MessagesAndConsts.LoginText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnLogin.Enabled = true;
                btnLogin.Text = MessagesAndConsts.LoginText;
                return;
            }
            CurrentUser.Id=result.Data.Id;
            CurrentUser.PhoneNumber = txtPhone.Text;
            
            ShowInfo(result.Message!);
            FormAdmin admin = new FormAdmin();
            admin.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnSignin_Click(object sender, EventArgs e)
        {
        }

        private async void btnGetUserByPhone_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnGetUserByEmail_Click(object sender, EventArgs e)
        {
        }

        private async void btnGetBrandById_Click(object sender, EventArgs e)
        {

        }

        private async void btnDeleteBrand_Click(object sender, EventArgs e)
        {
        }

        private async void btnGetBrandByName_Click(object sender, EventArgs e)
        {
        }

        private async void btnGetBrandByCategoryName_Click(object sender, EventArgs e)
        {
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
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

