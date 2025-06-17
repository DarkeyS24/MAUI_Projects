using AppTask.Database.Repositories;
using AppTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private ITaskModelRepository repository;

        public TasksController(ITaskModelRepository rep)
        {
            repository = rep;
        }

        [HttpGet]
        public IActionResult GetAll(Guid userId)
        {
            var tasks = repository.GetAllTasks(userId);
            if (tasks == null)
                return NotFound();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var task = repository.GetTaskById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult Add(TaskModel entity)
        {
            repository.AddTask(entity);
            return Ok(entity);
        }

        [HttpPut]
        public IActionResult Update(TaskModel entity)
        {
            repository.UpdateTask(entity);
            return Ok(entity);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = repository.GetTaskById(id);
            repository.DeleteTask(entity);
            return Ok();
        }

        [HttpPost("BatchPush/{userId}")]
        public IActionResult BatchPush(Guid userId, [FromBody]List<TaskModel> tasks)
        {
            foreach (var task in tasks)
            {
                var taskDB = repository.GetTaskById(task.Id);
                if (taskDB == null)
                {
                    repository.AddTask(task);
                }
                else
                {
                    if (task.Updated > taskDB.Updated)
                    {
                        repository.UpdateTask(task);
                    }
                }
            }
            return Ok(repository.GetAllTasks(userId));
        }
    }
}
