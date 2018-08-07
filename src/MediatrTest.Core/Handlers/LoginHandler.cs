using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrTest.Core.Interfaces.LoginService;
using MediatrTest.Core.Models.Messages;

namespace MediatrTest.Core.Handlers
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ILoginService _loginService;

        public LoginHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _loginService.LoginAsync(request.Username, request.Password)
                                                .ConfigureAwait(false);

                return LoginResponse.WithStatus(result);
            }
            catch (System.Exception ex)
            {
                return LoginResponse.WithStatusAndMessage(false, ex.Message);
            }
        }
    }
}
