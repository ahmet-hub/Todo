using System;

namespace Todo.Core.Dtos
{
    public class TaskItemDto
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string UserId { get; set; }
    }
}
