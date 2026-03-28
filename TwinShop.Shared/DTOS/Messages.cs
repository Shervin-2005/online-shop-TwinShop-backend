using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.Shared.DTOS
{
    public class Messages
    {
        public const string InternetErrorMessage = "اتصال اینترنت خود را بررسی کنید و دوباره تلاش کنید. در صورت تکرار مشکل، با پشتیبانی تماس بگیرید.";
        public const string Url = "https://";
        public const string pleaseWaitText = "صبر کنید";
        public const string LoginText = "Login Succssesfuly!";
        public const string SingUpText = "ثبت نام";
        //======================================================================================================
        public const string SuccessSignUp1 = "Succssesfully signed in!";
        public const string FailedSignUp1 = "Your Sign in Went Wrong!!";
        public const string FailedLogin = "Your informition is not valid!!";
        public const string PasswordNotMatch = "Passwords doesn't match together";
        public const string ExistingUser = "این نام کاربری توسط شخصی دیگر انتخاب شده";
        public const string NumberInvalid1 = "Phone number must be 11 characters!";
        public const string PhoneNumberAlreadyExist = "This phone number is already exist";
        public const string EmailAlreadyExist = "This email address is already exist";
        public const string lastNameInvalid1 = "This is not an appropirate last name";
        public const string lastNameInvalid2 = "Last name is to long!";
        public const string firstNameInvalid1 = "First name can't be less than three";
        public const string firstNameInvalid2 = "First name is to long!";
        public const string numberInvalid2 = "phone number is not valid";
        public const string EmailInvalid = "ایمیل معتبر نمی باشد";
        public const string EnterPassword = "Enter a password";
        public const string successSignUp2 = "ثبت نام شما انجام شد";
        public const string failedSignUp2 = "ثبت نام شما انجام نشد";
        public const string notSavePhoto = "مشکلی پیش امده عکس ذخیره نشد";
        public const string photoNotSelected = "لطفا یک عکس برای پروفایل خود انتخاب کنید";
        public const string enterTheAddress = "آدرس را وارد کنید";
        public const string enterTheWorkHistory = "سابقه کاری نمی تواند کمتر از 1 رقم و بیشتر از سه رقم باشد.";
        public const string error = "There is a problem! pls call our assistant";
        public const string codeError = "Code Error!";
        public const string update = "Succsessfuly updated";
        public const string Mandatory = "Please Fill the necesery field";
        public const string userNotLoginWithThisPhoneNumber = "Can't find any user with this number,Are you registered before?!";
        public const string IncorrectPhoneNumberOrPassword = "Phonenumber or password is not correct";
        //==============================================================================================================================
        public const string ProductName = "Please enter the name of the product";
        public const string ProductInitialPrice = "Please enter the initial price";
        public const string ProductSecondryPrice = "Please enter the second price";
        public const string ValidProductPrice = "Please enter price of the product in numbers";
        public const string ProductNumber = "Enter number of your Product";
        public const string ProductDescription = "Please write description for your product";
        public const string ProductDescriptionLength = "Description must be less than 2000 characters";
        public const string ProductBrandId = "Please Enter the brand Id of the product";
        public const string ProductBrandName = "Please Enter the brand name of the product";
        public const string ProductCategoryName = "Please Enter the Catgory name of the product";
        public const string ProductPhoto = "Please upload an image for your Product";
        public const string ProductAdded = "The product Added Successfuly";
        public const string ConfirmDeleteProduct = "آیا از حذف محصول مطمئن هستید؟";
        public const string DeleteProduct = "Product deleted successfuly";
        public const string ProductHasUnsentOrders = "این محصول دارای سفارش ارسال‌نشده است. لطفاً ابتدا سفارش‌های مربوطه را ارسال کنید و سپس دوباره برای حذف محصول اقدام نمایید.";
        //=================================================================================================================
        public const string CategoryName = "Please enter the name of the category";
        public const string CategoryPhoto = "Please upload an image for your category";
        public const string CategoryAdded = "The category Added Successfully";
        public const string DeleteCategory = "Category deleted successfuly";
        //=================================================================================================================
        public const string BrandName = "Please enter the name of the brand";
        public const string BrandCategoryName = "Please Enter the Catgory name of the brand";
        public const string BrandCategoryId = "Please Enter the category Id of the brand";
        public const string BrandPhoto = "Please upload an image for your brand";
        public const string BrandAdded = "The brand Added Successfully";
        public const string DeleteBrand = "Brand deleted successfuly";
        //=================================================================================================================
        public const string NullOrder = "سفارش پیدا نشد";
        public const string RejectedOrder = "سفارش رد شد";
        public const string SentOrder = "سفارش ارسال شد";
        //====================================================================================================================
        public const string EnterDataBuilt = "تاریخ احداث را با فرمت 1380/12/24 وارد کنید ";
        public const string EnterLandArea = "مساحت زمین قابل کشت را به عدد وارد کنید";
        public const string EnterCodParvaneBHB = "شماره پروانه بهره برداری را درست وارد کنید";
        public const string EnterCodePosti = "کد پستی را درست وارد کنید";
        public const string NotValidNationalCode = "کد ملی معتبر نیست";
        //====================================================================================================================
        public const string successAddToCart = "با موفقیت به سبد خرید اضافه شد";
        public const string RemoveAddToCart = "با موفقیت از سبد خرید حذف شد";
        public const string CartEmpty = "سبد خرید خالی است";
        //=====================================================================================================================
        public const string ShoppingSuccessful = "خرید با موفقیت انجام شد";
    }
}
