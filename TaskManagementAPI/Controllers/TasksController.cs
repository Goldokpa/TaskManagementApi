using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        // Temporary in-memory data store
        private static List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Task 1",
                Description = "First task description",
                DueDate = DateTime.Now.AddDays(2),
                Category = "Work",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Task 2",
                Description = "Second task description",
                DueDate = DateTime.Now.AddDays(5),
                Category = "Personal",
                IsCompleted = true
            }
        };

        // GET: api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            return _tasks;
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<TaskItem> PostTask(TaskItem task)
        {
            task.Id = Guid.NewGuid().ToString();
            _tasks.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult PutTask(string id, TaskItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.Category = updatedTask.Category;
            task.IsCompleted = updatedTask.IsCompleted;

            return NoContent();
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            _tasks.Remove(task);

            return NoContent();
        }
    }
}
