namespace TaskBoard.API.Models
{
    public class GetAllTasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public string AssignedUserName { get; set; }
    }
}
