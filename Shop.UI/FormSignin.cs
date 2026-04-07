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
            btnSignin.Text = Messages.pleaseWaitText;
            var userViewModel = new UserViewModel()
            {
                PhoneNumber = txtPhone.Text,
                Password = txtPassword.Text,
            };
            if (!userViewModel.IsValid)
            {
                ShowInfo(userViewModel.ErrorMessage);
                btnSignin.Enabled=true;
                btnSignin.Text= Messages.SingUpText;
                return;
            }
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, UserViewModel>(RouteConstants.Register, userViewModel);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btnSignin.Enabled = true;
                btnSignin.Text = Messages.SingUpText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnSignin.Enabled = true;
                btnSignin.Text = Messages.SingUpText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
        }

        private void FormSignin_Load(object sender, EventArgs e)
        {

        }
    }
}
