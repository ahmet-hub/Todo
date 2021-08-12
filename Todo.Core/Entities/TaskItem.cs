using System;

namespace Todo.Core.Entities
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
