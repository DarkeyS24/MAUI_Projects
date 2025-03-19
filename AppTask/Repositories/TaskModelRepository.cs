using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTask.Database;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Repositories
{
    class TaskModelRepository : ITaskModelRepository
    {
        private AppTaskContext db;
        public TaskModelRepository()
        {
            db = new AppTaskContext();
        }

        public IList<TaskModel> GetAllTasks()
        {
            return db.Tasks.OrderByDescending(a=>a.PrevisionDate).ToList();
        }

        public TaskModel GetTaskById(int taskId)
        {
            return db.Tasks.Include(a => a.Sub_Tasks).SingleOrDefault(a => a.Id == taskId);
        }

        public void AddTask(TaskModel task)
        {
            db.Tasks.Add(task); 
            db.SaveChanges();
        }

        public void UpdateTask(TaskModel task)
        {
            db.Tasks.Update(task);
            db.SaveChanges();
        }

        public void DeleteTask(TaskModel task)
        {
            task = GetTaskById(task.Id);
            foreach (var item in task.Sub_Tasks)
            {
                db.SubTasks.Remove(item);
            }
            db.Tasks.Remove(task);
            db.SaveChanges();
        }
    }
}