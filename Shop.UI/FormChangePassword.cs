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
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Shop.UI
{
    public partial class FormChangePassword : FormStyle
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {

        }

        private  async void btnChange_Click(object sender, EventArgs e)
        {
           btnChange.Enabled = false;
           btnChange.Text=MessagesAndConsts.pleaseWaitText;

            var changePasswordViewModel = new ChangePasswordUserViewModel()
            {
                CurrentPassword = txtCurrentPassword.Text,
                Password = txtNewPassword.Text,
                RepeatPassword = txtRepeatNewPassword.Text
            };
            if (!changePasswordViewModel.IsValid)
            {
                ShowInfo(changePasswordViewModel.ErrorMessage);
                btnChange.Enabled = true;
                btnChange.Text = MessagesAndConsts.ApplyText;
                return;
            }

            string route = string.Format(RouteConstants.ChangePassword, CurrentUser.PhoneNumber);
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, ChangePasswordUserViewModel>(route, changePasswordViewModel);

            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnChange.Enabled = true;
                btnChange.Text = MessagesAndConsts.ApplyText;
                return;
            }

            if (!result.Success)
            {
                ShowInfo(result.Message!.ErrorMessage()!);
                btnChange.Enabled = true;
                btnChange.Text = MessagesAndConsts.ApplyText;
                return;
            }
            CurrentUser.PasswordLength=txtNewPassword.Text.Length;
            ShowInfo(result.Message!);
            this.Close();
        }
    }
}
