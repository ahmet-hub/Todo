using System;

namespace Todo.Core.Dtos
{
    public class TaskItemUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
