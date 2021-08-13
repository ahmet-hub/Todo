using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Application.Authentication.Interfaces;
using Todo.Core.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> AccesToken(AuthModel authModel)
        {
            var response = await _authenticationService.CreateAccessToken(authModel.Email, authModel.Password);

            if (!response.Error)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }
    }
}
