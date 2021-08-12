using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Core.Dtos;
using Todo.Core.Entities;
using Todo.Core.Models;

namespace Todo.Application.TodoItems.Interfaces
{
    public interface ITaskItemService
    {
        Task<Response<IEnumerable<TaskItemDto>>> GetAll();
        Task<Response<TaskItemDto>> Get(Expression<Func<TaskItem, bool>> predicate);
        Task<Response<TaskItemDto>> GetById(string id);
        Task<Response<TaskItemDto>> Add(TaskItemDto taskItemDto);
        Task<Response<TaskItemDto>> Update(TaskItemUpdateDto taskItemUpdateDto);
        Task<Response<TaskItemDto>> Delete(string id);
    }
}
