using MvvmCross.Forms.Views;
using MediatrTest.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace MediatrTest.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : MvxContentPage<StartViewModel>
    {
        public StartPage()
        {
            InitializeComponent();
        }
    }
}
