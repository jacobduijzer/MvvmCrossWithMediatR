using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Models.Messages;
using MvvmCross.Commands;

namespace MediatrTest.Core.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IMediator _mediator;

        public LoginViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(LoginAsync, () => CanLogin);

        private string _username;
        public string Username
        {
            get => _username;
            set { SetProperty(ref _username, value); RaisePropertyChanged(() => CanLogin); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value); RaisePropertyChanged(() => CanLogin); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            private set => SetProperty(ref _errorMessage, value);
        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && Username.Length >= 5 &&
                                       !string.IsNullOrEmpty(Password) && Password.Length >= 4;
        
        private async Task LoginAsync()
        {
            var result = await _mediator.Send(LoginRequest.WithCredentials(Username, Password))
                                        .ConfigureAwait(false);

            if (result.Succes)
                await NavigationService.Navigate<StartViewModel>()
                                       .ConfigureAwait(false);
            else
                ErrorMessage = result.Message;
        }
    }
}
