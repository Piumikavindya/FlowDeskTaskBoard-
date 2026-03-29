namespace TaskBoard.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; } // ToDo, InProgress, Done

        public string Priority { get; set; } // Low, Medium, High

        public DateTime DueDate { get; set; }

        public bool IsArchived { get; set; } = false;

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
    }
}
