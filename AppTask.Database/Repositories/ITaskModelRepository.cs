using AppTask.Models;

namespace AppTask.Database.Repositories
{
    public interface ITaskModelRepository
    {
        IList<TaskModel> GetAllTasks(Guid id);
        TaskModel GetTaskById(Guid taskId);
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(TaskModel task);
    }
}
