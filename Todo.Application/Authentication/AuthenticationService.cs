using System.Threading.Tasks;
using Todo.Application.Authentication.Interfaces;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Models;

namespace Todo.Application.Authentication
{
    public class AuthenticationService :IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenHandle _tokenHandle;

        public AuthenticationService(IRepository<User> userRepository, ITokenHandle tokenHandle)
        {
            _userRepository = userRepository;
            _tokenHandle = tokenHandle;
        }
        public async Task<Response<AccessToken>> CreateAccessToken(string email, string password)
        {

            var user = await _userRepository.GetFilterAsync(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                var accessToken = _tokenHandle.CreateAccessToken(user);
                return Response.Ok("Success", accessToken.Data);
            }
            else
            {
                return Response.Fail<AccessToken>("User Not Found");
            }
        }
    }
}
