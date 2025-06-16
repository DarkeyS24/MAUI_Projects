using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AppTask.Models;

namespace AppTask.Services
{
    public class TaskService : ITaskService
    {
        private HttpClient http;
        public TaskService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<List<TaskModel>> GetAll(Guid userId)
        {
            return await http.GetFromJsonAsync<List<TaskModel>>($"Tasks?userId={userId}");
        }
        public async Task<TaskModel> GetById(Guid id)
        {
            return await http.GetFromJsonAsync<TaskModel>($"Tasks?id={id}");
        }
        public async Task Add(TaskModel task)
        {
            await http.PostAsJsonAsync<TaskModel>("Tasks", task);
        }
        public async Task Update(TaskModel task)
        {
            await http.PutAsJsonAsync<TaskModel>("Tasks", task);
        }
        public async Task DeleteTask(Guid id)
        {
            await http.DeleteAsync($"Tasks/{id}");
        }
        public async Task BatchPush(List<TaskModel> tasks)
        {
            await http.PostAsJsonAsync($"Tasks/BatchPush", tasks);
        }
    }
}
