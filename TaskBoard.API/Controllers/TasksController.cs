using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.API.Interfaces;
using TaskBoard.API.Models;

namespace TaskBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> Create([FromBody] TaskCreate model)
        {
            var task = new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                Status = model.Status,
                Priority = model.Priority,
                DueDate = model.DueDate,
                ProjectId = model.ProjectId,
                AssignedUserId = model.AssignedUserId
            };

            var created = await _taskService.CreateTask(task);

            return Ok(created);
        }

        [HttpPut]
        [Route("UpdateTask/{id}")]
        public async Task<IActionResult> Update(int id, TaskCreate task)
        {
            var updated = await _taskService.UpdateTask(id, task);

            if (updated == null)
                return NotFound("Task not found");

            return Ok(updated);
        }

        [HttpDelete]
        [Route("DeleteTask/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.DeleteTask(id);

            if (!result)
                return NotFound("Task not found");

            return Ok("Deleted successfully");
        }

        [HttpPatch]
        [Route("ArchiveTask/{id}")]
        public async Task<IActionResult> Archive(int id)
        {
            var result = await _taskService.ArchiveTask(id);

            if (!result)
                return NotFound("Task not found");

            return Ok("Task archived");
        }
    }
}