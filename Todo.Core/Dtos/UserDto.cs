﻿using System.Collections.Generic;

namespace Todo.Core.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TaskItemDto> TodoList { get; set; }
    }
}