using AutoMapper;
using Todo.Core.Dtos;
using Todo.Core.Entities;

namespace Todo.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<User, UserDto>();

            CreateMap<TaskItemDto, TaskItem>();
            CreateMap<UserDto, User>();
        }
    }
}
