using System.Threading.Tasks;
using Todo.Core.Models;

namespace Todo.Application.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Response<AccessToken>> CreateAccessToken(string email, string password);
    }
}
