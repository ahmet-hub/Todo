using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Application.Users.Interfaces;
using Todo.Core.Dtos;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Models;

namespace Todo.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UserDto>>> GetAll()
        {
            try
            {
                var result = await _userRepository.GetAllAsync();

                return Response.Ok("Success", _mapper.Map<IEnumerable<UserDto>>(result));
            }
            catch (Exception ex)
            {

                return Response.Fail<IEnumerable<UserDto>>(ex.Message);
            }
        }
        public async Task<Response<UserDto>> Get(Expression<Func<User, bool>> predicate)
        {
            try
            {
                var result = await _userRepository.GetFilterAsync(predicate);

                return Response.Ok("Success", _mapper.Map<UserDto>(result));
            }
            catch (Exception ex)
            {
                return Response.Fail<UserDto>(ex.Message);
            }
        }
        public async Task<Response<UserDto>> GetById(string id)
        {
            try
            {
                var result = await _userRepository.GetAsync(id);

                return Response.Ok("Success", _mapper.Map<UserDto>(result));
            }
            catch (Exception ex)
            {
                return Response.Fail<UserDto>(ex.Message);
            }
        }
        public async Task<Response<UserDto>> Add(UserDto UserDto)
        {
            try
            {
                var X = _mapper.Map<User>(UserDto);
                await _userRepository.AddAsync(_mapper.Map<User>(UserDto));

                return Response.Ok<UserDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<UserDto>(ex.Message);
            }
        }

        public async Task<Response<UserDto>> Update(UserUpdateDto UserDto)
        {
            try
            {
                await _userRepository.Update(_mapper.Map<User>(UserDto));

                return Response.Ok<UserDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<UserDto>(ex.Message);
            }
        }

        public async Task<Response<UserDto>> Delete(string id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);

                return Response.Ok<UserDto>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<UserDto>(ex.Message);
            }
        }
    }
}
