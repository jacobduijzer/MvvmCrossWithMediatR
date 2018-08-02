using FluentAssertions;
using MediatrTest.Core.ViewModels;
using Xunit;
using System.Threading.Tasks;

namespace MediatrTest.Tests.ViewModels
{
    public class StartViewModelShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public StartViewModelShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Construct()
        {
            var vm = _fixture.Ioc.IoCConstruct<StartViewModel>();
            vm.Should()
              .BeOfType<StartViewModel>();
        }

        [Fact]
        public async Task ExecutePingHandler()
        {
            var vm = _fixture.Ioc.IoCConstruct<StartViewModel>();

            vm.PingResult
              .Should()
              .BeNullOrEmpty();

            vm.PingCommand
              .CanExecute()
              .Should()
              .BeTrue();

            await vm.PingCommand
                    .ExecuteAsync()
                    .ConfigureAwait(false);

            vm.PingResult
              .Should()
              .Be("Ping Pong");
        }

        [Fact]
        public async Task ExecuteOneWayHandler()
        {
            var vm = _fixture.Ioc.IoCConstruct<StartViewModel>();

            vm.OneWayResult
              .Should()
              .BeNullOrEmpty();

            vm.OneWayCommand
              .CanExecute()
              .Should()
              .BeTrue();

            await vm.OneWayCommand
                    .ExecuteAsync()
                    .ConfigureAwait(false);

            vm.OneWayResult
              .Should()
              .NotBeNullOrEmpty()
              .And
              .Contain("no errors");
        }
    }
}
