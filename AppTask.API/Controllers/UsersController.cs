using AppTask.API.Libraries.Constants;
using AppTask.API.Libraries.Emails;
using AppTask.API.Libraries.Text;
using AppTask.Database.Repositories;
using AppTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserModelRepository repository;
        private EmailsAccessToken EAT;

        public UsersController(IUserModelRepository _rep, EmailsAccessToken email)
        {
            repository = _rep;
            EAT = email;
        }

        [HttpGet]
        public ActionResult GetUser(string email)
        {
            var user = repository.GetUser(email);
            if (user == null)
            {
                user = new UserModel() 
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    AcccessToken = "".GenerateHash(4),
                    AccessTokenCreated = DateTimeOffset.Now,
                    UserCreated = DateTimeOffset.Now
                };

                repository.AddUser(user);
            }
            else
            {
                user.AcccessToken = string.Empty.GenerateHash(4);
                user.AccessTokenCreated = DateTimeOffset.Now;

                repository.UpdateUser(user);
            }

            EAT.SendEmail(user);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult ValidateAccessToken(UserModel user)
        {
            var newUser = repository.GetUser(user.Email);
            if (newUser == null)
            return NotFound("Access token doesn't exist");

            if (newUser.AcccessToken == user.AcccessToken)
            {
                var tokenLimitHours = newUser.AccessTokenCreated.Add(Config.LimitAccessTokenCreated);
                var serverHours = DateTimeOffset.Now;
                if (serverHours <= tokenLimitHours)
                {
                    return Ok(newUser);
                }
            }
            return BadRequest("Invalid access token!");
        }
    }
}
