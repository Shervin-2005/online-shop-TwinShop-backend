using Shop.UI.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Shop.UI.User.UI
{
    public partial class LoginWithCode : FormStyle
    {
        public LoginWithCode()
        {
            InitializeComponent();
        }

        private void lblSignin_Click(object sender, EventArgs e)
        {
            FormSignin formSignin = new FormSignin();
            formSignin.ShowDialog();
        }

        private void lblLoginWithPass_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            btnSendCode.Enabled = false;
            btnSendCode.Text = MessagesAndConsts.pleaseWaitText;
            LoginWithCodeUserViewModel loginWithCodeUserViewModel = new LoginWithCodeUserViewModel
            {
                PhoneNumber = txtPhone.Text,
            };
            if (!loginWithCodeUserViewModel.IsValid)
            {
                ShowInfo(loginWithCodeUserViewModel.ErrorMessage);
                btnSendCode.Enabled = true;
                btnSendCode.Text = MessagesAndConsts.SendCodeText;
                return;
            }
            var client = HttpClientHelper.Instance;
            string route = string.Format(RouteConstants.SendOtp, txtPhone.Text);
            var result = await client.PostAsync<OperationResult, string>(RouteConstants.SendOtp, loginWithCodeUserViewModel.PhoneNumber);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnSendCode.Enabled = true;
                btnSendCode.Text = MessagesAndConsts.SendCodeText;
                return;
            }

            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnSendCode.Enabled = true;
                btnSendCode.Text = MessagesAndConsts.SendCodeText;
                return;
            }
            CurrentUser.PhoneNumber = txtPhone.Text;
            ShowInfo(result.Message!);
            btnSendCode.Enabled = true;
            btnSendCode.Text = MessagesAndConsts.SendCodeText;

            VerifyCode verifyCode = new VerifyCode();
            verifyCode.Show();


        }
    }
}
