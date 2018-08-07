using System.Threading.Tasks;
using FluentAssertions;
using MediatrTest.Core.ViewModels.Login;
using Xunit;
using MvvmCross.ViewModels;
using Moq;
using System.Threading;
using MediatrTest.Core.ViewModels;

namespace MediatrTest.Tests.ViewModels.Login
{
    public class LoginViewModelShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public LoginViewModelShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Construct()
        {
            var vm = _fixture.Ioc.IoCConstruct<LoginViewModel>();
            
            vm.Should()
              .BeOfType<LoginViewModel>();
        }

        [Fact]
        public void RaiseAndValidateWhenTyping()
        {
            var vm = _fixture.Ioc.IoCConstruct<LoginViewModel>();
            vm.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);

            using(var monitoredVM = vm.Monitor())
            {
                vm.CanLogin
                  .Should()
                  .BeFalse("no credentials are entered");

                vm.LoginCommand
                  .CanExecute()
                  .Should()
                  .BeFalse("no credentials are entered");

                vm.Username = "test@test.com";
                vm.Password = "test1234";

                vm.CanLogin
                  .Should()
                  .BeTrue("credentials are entered and correct");

                vm.LoginCommand
                  .CanExecute()
                  .Should()
                  .BeTrue("credentials are entered so command can execute");

                monitoredVM.Should()
                           .RaisePropertyChangeFor(x => x.Username);

                monitoredVM.Should()
                           .RaisePropertyChangeFor(x => x.Password);

                monitoredVM.Should()
                           .RaisePropertyChangeFor(x => x.CanLogin);
            }
        }

        [Fact]
        public async Task NavigateWhenTheCredentialsAreValid()
        {
            var vm = _fixture.Ioc.IoCConstruct<LoginViewModel>();
            vm.ShouldAlwaysRaiseInpcOnUserInterfaceThread(false);

            vm.Username = "test@test.com";
            vm.Password = "test1234";

            vm.LoginCommand
              .CanExecute()
              .Should()
              .BeTrue();

            await vm.LoginCommand
                    .ExecuteAsync()
                    .ConfigureAwait(false);

            _fixture.MockNavigationService.Verify(x => x.Navigate<StartViewModel>(It.IsAny<IMvxBundle>(), It.IsAny<CancellationToken>()), Times.Once);
        }

    }
}
