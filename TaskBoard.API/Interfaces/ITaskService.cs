using TaskBoard.API.Models;

namespace TaskBoard.API.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<GetAllTasks>> GetAllTasks();

        Task<TaskItem> GetTaskById(int id);

        Task<TaskItem> CreateTask(TaskItem task);

        Task<TaskItem> UpdateTask(int id, TaskCreate task);

        Task<bool> DeleteTask(int id);

        Task<bool> ArchiveTask(int id);
    }
}
