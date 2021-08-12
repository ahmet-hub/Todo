using System.Collections.Generic;

namespace Todo.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TaskItem> TodoList { get; set; }
    }
}
