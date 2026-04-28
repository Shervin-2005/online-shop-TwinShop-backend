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
    public partial class VerifyCode : FormStyle
    {
        private int remainingSeconds = 120;
        public VerifyCode()
        {
            InitializeComponent();
        }

        private async void btnEnterCode_Click(object sender, EventArgs e)
        {
            btnEnterCode.Enabled = false;
            btnEnterCode.Text = MessagesAndConsts.EnterCodeText;
            var client = HttpClientHelper.Instance;
            string? code = txtCode.Text;
            LoginWithCodeUserViewModel loginWithCodeUserViewModel = new LoginWithCodeUserViewModel
            {
                PhoneNumber = CurrentUser.PhoneNumber,
                Code = code,
            };
            if (!loginWithCodeUserViewModel.IsValid)
            {
                ShowInfo(loginWithCodeUserViewModel.ErrorMessage);
                btnEnterCode.Enabled = true;
                btnEnterCode.Text = MessagesAndConsts.EnterCodeText;
                return;
            }
            var result = await client.PostAsync < OperationResult, LoginWithCodeUserViewModel>(RouteConstants.VerifyOtp,loginWithCodeUserViewModel);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnEnterCode.Enabled = true;
                btnEnterCode.Text = MessagesAndConsts.EnterCodeText;
                return;
            }

            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnEnterCode.Enabled = true;
                btnEnterCode.Text = MessagesAndConsts.EnterCodeText;
                return;
            }
            ShowInfo(result.Message!);
            btnEnterCode.Enabled = true;
            btnEnterCode.Text = MessagesAndConsts.EnterCodeText;

            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
        }

        private void VerifyCode_Load(object sender, EventArgs e)
        {
            remainingSeconds = 120;
            lblTimer.Text = "02:00";
            OtpTimer.Start();
        }

        private void Otptimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
            lblTimer.Text = time.ToString(@"mm\:ss");

            if (remainingSeconds <= 0)
            {
                OtpTimer.Stop();
                lblTimer.Text = "00:00";
            }
        }
    }
}
