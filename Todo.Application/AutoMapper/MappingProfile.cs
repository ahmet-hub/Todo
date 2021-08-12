using AutoMapper;
using Todo.Core.Dtos;
using Todo.Core.Entities;

namespace Todo.Application.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
