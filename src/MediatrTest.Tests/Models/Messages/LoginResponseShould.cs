using FluentAssertions;
using MediatrTest.Core.Models.Messages;
using Xunit;

namespace MediatrTest.Tests.Models.Messages
{
    public class LoginResponseShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public LoginResponseShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Construct()
        {
            var response = LoginResponse.WithStatus(true);
            response.Should()
                    .BeOfType<LoginResponse>();
        }

        [Fact]
        public void ContainStatus()
        {
            var response = LoginResponse.WithStatus(true);
            response.Succes
                    .Should()
                    .BeTrue();
        }

        [Fact]
        public void ContainStatusAndMessage()
        {
            var message = "An error occured";

            var response = LoginResponse.WithStatusAndMessage(false, message);
            response.Succes
                    .Should()
                    .BeFalse();

            response.Message
                    .Should()
                    .Be(message);
        }
    }
}
