using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Application.TodoItems.Interfaces;
using Todo.Core.Dtos;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Models;

namespace Todo.Application.TodoItems
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IRepository<TaskItem> _userRepository;
        private readonly IMapper _mapper;

        public TaskItemService(IRepository<TaskItem> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TaskItemDto>>> GetAll()
        {
            try
            {
                var result = await _userRepository.GetAllAsync();

                return Response.Ok("Success", _mapper.Map<IEnumerable<TaskItemDto>>(result));
            }
            catch (Exception ex)
            {

                return Response.Fail<IEnumerable<TaskItemDto>>(ex.Message);
            }
        }
        public async Task<Response<TaskItemDto>> Get(Expression<Func<TaskItem, bool>> predicate)
        {
            try
            {
                var result = await _userRepository.GetFilterAsync(predicate);

                return Response.Ok("Success", _mapper.Map<TaskItemDto>(result));
            }
            catch (Exception ex)
            {
                return Response.Fail<TaskItemDto>(ex.Message);
            }
        }
        public async Task<Response<TaskItemDto>> GetById(string userId, string taskItemId)
        {
            try
            {
                var userTaskItems = await _userRepository.GetWhereAsync(x => x.UserId == userId);

                var result = userTaskItems.FirstOrDefault(x => x.Id == taskItemId);

                if (result == null) return Response.Fail<TaskItemDto>("Not Found");

                return Response.Ok("Success", _mapper.Map<TaskItemDto>(result));
            }
            catch (Exception ex)
            {
                return Response.Fail<TaskItemDto>(ex.Message);
            }
        }
        public async Task<Response<TaskItemDto>> Add(TaskItemDto taskItemDto)
        {
            try
            {
                await _userRepository.AddAsync(_mapper.Map<TaskItem>(taskItemDto));

                return Response.Ok<TaskItemDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<TaskItemDto>(ex.Message);
            }
        }

        public async Task<Response<TaskItemDto>> Update(TaskItemUpdateDto taskItemDto)
        {
            try
            {
                await _userRepository.Update(_mapper.Map<TaskItem>(taskItemDto));

                return Response.Ok<TaskItemDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<TaskItemDto>(ex.Message);
            }
        }

        public async Task<Response<TaskItemDto>> Delete(string id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);

                return Response.Ok<TaskItemDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<TaskItemDto>(ex.Message);
            }
        }

        public async Task<Response<IEnumerable<TaskItemDto>>> GetWhere(string userId)
        {
            try
            {
                var result = await _userRepository.GetWhereAsync(x => x.UserId == userId);

                return Response.Ok("Success", _mapper.Map<IEnumerable<TaskItemDto>>(result));
            }
            catch (Exception ex)
            {

                return Response.Fail<IEnumerable<TaskItemDto>>(ex.Message);
            }
        }
    }
}
