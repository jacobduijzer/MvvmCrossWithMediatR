using FluentAssertions;
using MediatrTest.Core.Handlers;
using Xunit;

namespace MediatrTest.Tests.Handlers
{
    public class LoginHandlerShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public LoginHandlerShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Construct()
        {
            var handler = _fixture.Ioc.IoCConstruct<LoginHandler>();
            handler.Should()
                   .BeOfType<LoginHandler>();

        }
    }
}
