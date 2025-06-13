using AppTask.Models;

namespace AppTask.Database.Repositories
{
    public class UserModelRepository : IUserModelRepository
    {
        private AppTaskContext _context;
        public UserModelRepository(AppTaskContext context)
        {
            _context = context;
        }

        public UserModel GetUser(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public void AddUser(UserModel user)
        {
            user.Id = Guid.NewGuid(); // Ensure a new GUID is generated for the user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserModel user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
