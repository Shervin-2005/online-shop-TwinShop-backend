using Shop.UI.Http;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace Shop.UI
{
    public partial class FormSignin : FormStyle
    {

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

        private async void btnSignin_Click(object sender, EventArgs e)
        {
            btnSignin.Enabled = false;
            btnSignin.Text = MessagesAndConsts.pleaseWaitText;
            var userViewModel = new UserViewModel()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
                RepeatPassword=txtRepeatPassword.Text,
                ProfileImage = MessagesAndConsts.DefaultProfile
            };
            if (!userViewModel.IsValid)
            {
                ShowInfo(userViewModel.ErrorMessage);
                btnSignin.Enabled = true;
                btnSignin.Text = MessagesAndConsts.SingUpText;
                return;
            }
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, UserViewModel>(RouteConstants.Register, userViewModel);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnSignin.Enabled = true;
                btnSignin.Text = MessagesAndConsts.SingUpText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnSignin.Enabled = true;
                btnSignin.Text = MessagesAndConsts.SingUpText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void FormSignin_Load(object sender, EventArgs e)
        {

        }

        private void txtRepeatPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
