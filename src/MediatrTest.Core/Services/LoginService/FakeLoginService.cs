using System.Threading.Tasks;
using MediatrTest.Core.Interfaces.LoginService;

namespace MediatrTest.Core.Services.LoginService
{
    public class FakeLoginService : ILoginService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(300)
                      .ConfigureAwait(false);

            if (username.Contains("wrong"))
                return false;

            return true;
        }
    }
}
