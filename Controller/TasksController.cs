using Microsoft.AspNetCore.Mvc;
using SmartTasker.Models;
using SmartTasker.Data;
using System.Linq;

namespace SmartTasker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks() => Ok(_context.Tasks.ToList());

        [HttpPost]
        public IActionResult AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem updatedTask)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.Priority = updatedTask.Priority;
            task.IsDone = updatedTask.IsDone;
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return Ok();
        }
    }
}
