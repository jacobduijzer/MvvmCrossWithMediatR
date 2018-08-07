using MediatrTest.Core.ViewModels.Login;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;
using MvvmCross.Forms.Presenters.Attributes;

namespace MediatrTest.Core.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentationAttribute(WrapInNavigationPage = true)]
    public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
