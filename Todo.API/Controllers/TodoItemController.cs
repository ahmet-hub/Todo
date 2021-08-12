using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo.Application.TodoItems.Interfaces;
using Todo.Core.Dtos;

namespace Todo.API.Controllers
{
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

            var result = await _taskItemService.GetAll();

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(string id)
        {

            var result = await _taskItemService.Get(x => x.Id == id);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemDto taskItemDto)
        {
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
            var result = await _taskItemService.Update(taskItemDto);

            if (!result.Error)
            {
                return Ok(result);
            }

            return BadRequest(result.Error);
        }
    }
}
