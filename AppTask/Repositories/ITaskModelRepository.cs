using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTask.Models;

namespace AppTask.Repositories
{
    public interface ITaskModelRepository
    {
        IList<TaskModel> GetAllTasks();
        TaskModel GetTaskById(int taskId);
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(TaskModel task);
    }
}
