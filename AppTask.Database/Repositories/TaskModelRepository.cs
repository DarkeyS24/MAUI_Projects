using AppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Database.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private AppTaskContext db;
        public TaskModelRepository()
        {
            db = new AppTaskContext();
        }

        public IList<TaskModel> GetAllTasks(Guid id)
        {
            return db.Tasks.Where(t => t.UserId == id).OrderByDescending(a=>a.PrevisionDate.ToString()).ToList();
        }

        public TaskModel GetTaskById(Guid taskId)
        {
            return db.Tasks.Include(a => a.Sub_Tasks).SingleOrDefault(a => a.Id == taskId);
        }

        public void AddTask(TaskModel task)
        {
            db.Tasks.Add(task); 
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void UpdateTask(TaskModel task)
        {
            db.ChangeTracker.Clear();
            db.Tasks.Update(task);
            db.SaveChanges();
        }

        public void DeleteTask(TaskModel task)
        {
            task = GetTaskById(task.Id);
            foreach (var item in task.Sub_Tasks)
            {
                db.ChangeTracker.Clear();
                item.Deleted = DateTimeOffset.Now;
                db.SubTasks.Update(item);
            }
            task.Deleted = DateTimeOffset.Now;
            db.Tasks.Update(task);
            db.SaveChanges();
        }
    }
}