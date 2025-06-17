using AppTask.Models;

namespace AppTask.Services
{
    public interface ITaskService
    {
        Task Add(TaskModel task);
        Task<List<TaskModel>> BatchPush(Guid userId, List<TaskModel> tasks);
        Task DeleteTask(Guid id);
        Task<List<TaskModel>> GetAll(Guid userId);
        Task<TaskModel> GetById(Guid id);
        Task Update(TaskModel task);
    }
}