using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Core.Dtos;
using Todo.Core.Entities;
using Todo.Core.Models;

namespace Todo.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<Response<IEnumerable<UserDto>>> GetAll();
        Task<Response<UserDto>> Get(Expression<Func<User, bool>> predicate);
        Task<Response<UserDto>> GetById(string id);
        Task<Response<UserDto>> Add(UserDto UserDto);
        Task<Response<UserDto>> Update(UserUpdateDto UserDto);
        Task<Response<UserDto>> Delete(string id);
    }
}
