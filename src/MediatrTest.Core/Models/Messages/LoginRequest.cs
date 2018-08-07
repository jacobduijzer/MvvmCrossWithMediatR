using MediatR;

namespace MediatrTest.Core.Models.Messages
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; }

        public string Password { get; }
        
        private LoginRequest(string username, string password)
        {
            Username = username;

            Password = password;
        }

        public static LoginRequest WithCredentials(string username, string password)
        => new LoginRequest(username, password);
    }
}
