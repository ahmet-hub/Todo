using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.Application.TodoItems.Interfaces;
using Todo.Core.Dtos;

namespace Todo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TodoItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currentUserId = GetCurrentUserId();
            var result = await _taskItemService.GetWhere(currentUserId);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var currentUserId = GetCurrentUserId();
            var result = await _taskItemService.GetById(currentUserId, id);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);

        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string name)
        {
            var currentUserId = GetCurrentUserId();
            var result = await _taskItemService.Get(x => x.UserId == GetCurrentUserId() && x.Name == name);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemDto taskItemDto)
        {
            taskItemDto.UserId = GetCurrentUserId();
            var result = await _taskItemService.Add(taskItemDto);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);

        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskItemUpdateDto taskItemDto)
        {
            taskItemDto.UserId = GetCurrentUserId();
            var result = await _taskItemService.Update(taskItemDto);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        private string GetCurrentUserId()
        {
            try
            {
                var claimsIdentity = this.User?.Identity as ClaimsIdentity;
                return claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
