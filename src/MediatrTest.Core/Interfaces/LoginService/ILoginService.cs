using System;
using System.Threading.Tasks;

namespace MediatrTest.Core.Interfaces.LoginService
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
