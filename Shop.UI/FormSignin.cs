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
            if (result.Success)
            {
                MessageBox.Show("wtf");
            }
            if (!result.Success)
            {
                ShowInfo(result.Message.ErrorMessage());
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
