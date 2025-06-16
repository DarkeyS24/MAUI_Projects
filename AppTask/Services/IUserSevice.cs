using AppTask.Models;

namespace AppTask.Services
{
    public interface IUserSevice
    {
        Task<UserModel> GetUser(string email);
        Task<UserModel> ValidateAccessToken(UserModel user);
    }
}