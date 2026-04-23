using Shop.UI.Http;
using System.ComponentModel;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.ViewModels.UserViewModels;
namespace Shop.UI
{
    public partial class FormEditUserInfo : FormStyle
    {
        string? profileImagePath;
        public FormEditUserInfo()
        {
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

        }

        private async void FormEditUserInfo_Load(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            string phoneNumber = Uri.UnescapeDataString(CurrentUser.PhoneNumber!);
            string route = string.Format(RouteConstants.GetUserbyPhoneNumber, phoneNumber);
            var userInfoViewModel = await client.GetAsync<OperationResult<UserInfoViewModel>>(route);
            if (userInfoViewModel == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                return;
            }
            if (!userInfoViewModel.Success)
            {
                ShowInfo(userInfoViewModel.Message!.ErrorMessage());
                return;
            }
            txtPassword.Text = new string('•', CurrentUser.PasswordLength);
            profileImagePath = userInfoViewModel.Data.ProfileImage;
            ProfilePictureBox.ImageLocation = profileImagePath;
            txtFirstName.Text = userInfoViewModel.Data.FirstName;
            txtLastName.Text = userInfoViewModel.Data.LastName;
            txtPhone.Text = userInfoViewModel.Data.PhoneNumber;
            txtEmail.Text = userInfoViewModel.Data.Email;
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            btnApply.Text = MessagesAndConsts.pleaseWaitText;
            var userInfoViewModel = new UserInfoViewModel()
            {
                Id = CurrentUser.Id,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhone.Text,
                Email = txtEmail.Text,
                ProfileImage = profileImagePath,

            };
            if (!userInfoViewModel.IsValid)
            {
                ShowInfo(userInfoViewModel.ErrorMessage);
                btnApply.Enabled = true;
                btnApply.Text = MessagesAndConsts.ApplyText;
                return;
            }

            string route = string.Format(RouteConstants.EditUserInfo, CurrentUser.PhoneNumber);
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, UserInfoViewModel>(route, userInfoViewModel);
            if (result == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                btnApply.Enabled = true;
                btnApply.Text = MessagesAndConsts.ApplyText;
                return;
            }
            if (!result.Success)
            {
                ShowInfo(result.Message!);
                btnApply.Enabled = true;
                btnApply.Text = MessagesAndConsts.ApplyText;
                return;
            }
            CurrentUser.PhoneNumber = userInfoViewModel.PhoneNumber;
            ShowInfo(result.Message!);
            this.Close();
        }

        private void ProfilePictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                profileImagePath = openFileDialog.FileName;
                ProfilePictureBox.ImageLocation = profileImagePath;
            }
        }

        private void ProfilePictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(ProfilePictureBox, "For choose a profile Please Click");
        }

        private void ProfilePictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
           // ProfilePictureBox.ImageLocation = profileImagePath;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.Show();
        }
    }
}
