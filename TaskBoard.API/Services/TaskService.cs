using Microsoft.EntityFrameworkCore;
using TaskBoard.API.Data;
using TaskBoard.API.Interfaces;
using TaskBoard.API.Models;

namespace TaskBoard.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.AssignedUser)
                .ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            if (string.IsNullOrEmpty(task.Title))
                throw new Exception("Title cannot be empty");

            if (task.DueDate < DateTime.UtcNow)
                throw new Exception("Due date cannot be in the past");

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskItem> UpdateTask(int id, TaskItem updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return null;

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;
            task.Priority = updatedTask.Priority;
            task.DueDate = updatedTask.DueDate;

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ArchiveTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null) return false;

            task.IsArchived = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}