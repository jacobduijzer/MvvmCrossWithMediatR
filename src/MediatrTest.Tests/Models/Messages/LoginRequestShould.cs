using FluentAssertions;
using MediatrTest.Core.Models.Messages;
using Xunit;

namespace MediatrTest.Tests.Models.Messages
{
    public class LoginRequestShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public LoginRequestShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Construct()
        {
            var request = LoginRequest.WithCredentials("testuser", "testpassword");
            request.Should()
                   .BeOfType<LoginRequest>();
        }
    }
}
