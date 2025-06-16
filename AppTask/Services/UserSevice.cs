using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AppTask.Models;

namespace AppTask.Services
{
    public class UserSevice : IUserSevice
    {
        private HttpClient http;

        public UserSevice(HttpClient http)
        {
            this.http = http;
        }

        public async Task<UserModel> GetUser(string email)
        {
            return await http.GetFromJsonAsync<UserModel>($"Users?email={email}");
        }
        public async Task<UserModel> ValidateAccessToken(UserModel user)
        {
            var response = await http.PostAsJsonAsync<UserModel>($"Users", user);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<UserModel>()
                : null;
        }
    }
}
