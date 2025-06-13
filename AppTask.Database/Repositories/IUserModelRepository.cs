using AppTask.Models;

namespace AppTask.Database.Repositories
{
    public interface IUserModelRepository
    {
        void AddUser(UserModel user);
        UserModel GetUser(string email);
        void UpdateUser(UserModel user);
    }
}