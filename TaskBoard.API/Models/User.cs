namespace TaskBoard.API.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public ICollection<TaskItem> AssignedTasks { get; set; }
    }
}
