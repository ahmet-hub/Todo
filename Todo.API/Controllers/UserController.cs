using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Application.Users.Interfaces;
using Todo.Core.Dtos;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _userService.GetAll();

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(string id)
        {

            var result = await _userService.Get(x => x.Id == id);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            var result = await _userService.Add(userDto);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);

        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            var result = await _userService.Update(userDto);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }
    }
}
