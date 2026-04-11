
using Shop.UI.Http;
using System.ComponentModel;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.ViewModels;
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
            string route = string.Format(RouteConstants.GetbyPhoneNumber, phoneNumber);
            var userView = await client.GetAsync<OperationResult<UserViewModel>>(route);
            if (userView == null)
            {
                ShowInfoError(MessagesAndConsts.InternetErrorMessage);
                return;
            }
            if (!userView.Success)
            {
                ShowInfo(userView.Message!.ErrorMessage());
                return;
            }
            profileImagePath = userView.Data.ProfileImage;
            txtFirstName.Text = userView.Data.FirstName;
            txtLastName.Text =userView.Data.LastName;
            txtPhone.Text = userView.Data.PhoneNumber;
            txtEmail.Text = userView.Data.Email;
            txtPassword.Text = userView.Data.Password;
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            btnApply.Text = MessagesAndConsts.pleaseWaitText;
            var userViewModel = new UserViewModel()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhone.Text,
                Email = txtEmail.Text,
                ProfileImage = profileImagePath,
                Password = txtPassword.Text,
            };
            if (!userViewModel.IsValid)
            {
                ShowInfo(userViewModel.ErrorMessage);
                btnApply.Enabled = true;
                btnApply.Text = MessagesAndConsts.ApplyText;
                return;
            }
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, UserViewModel>(RouteConstants.EditUserInfo, userViewModel);
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
                ProfilePictureBox.ImageLocation =profileImagePath;
            }
        }

        private void ProfilePictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(ProfilePictureBox, "For choose a profile Please Click");
        }

        private void ProfilePictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ProfilePictureBox.ImageLocation = profileImagePath;
        }
    }
}
