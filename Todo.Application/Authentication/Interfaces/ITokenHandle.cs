using Todo.Core.Entities;
using Todo.Core.Models;

namespace Todo.Application.Authentication.Interfaces
{
    public interface ITokenHandle
    {
        Response<AccessToken> CreateAccessToken(User user);
    }
}
