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
        public async Task ExecutePingOnInitialize()
        {
            var vm = _fixture.Ioc.IoCConstruct<StartViewModel>();

            vm.ErrorMessage
              .Should()
              .BeNullOrEmpty();

            await vm.Initialize()
                    .ConfigureAwait(false);

            vm.ErrorMessage
              .Should()
              .Be("Ping Pong");
        }
    }
}
