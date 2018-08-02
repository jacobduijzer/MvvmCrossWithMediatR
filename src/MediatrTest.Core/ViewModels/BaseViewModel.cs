using MvvmCross.Localization;
using MvvmCross.ViewModels;

namespace MediatrTest.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        public BaseViewModel()
        {
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(GetType().Assembly.GetName().Name, GetType().Name); }
        }
    }
}

