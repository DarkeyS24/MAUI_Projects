using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppTask.Models;

namespace AppTask.Libraries.Authentications
{
    public class UserAuth
    {
        private readonly static string UserLoggedKey = "user.logged";

        public static void SetUserLogged(UserModel user)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var userJson = JsonSerializer.Serialize(user, options);
            Preferences.Default.Set(UserLoggedKey, userJson);
        }

        public static UserModel GetUserLogged()
        {
            var userJson = Preferences.Default.Get<string>(UserLoggedKey, string.Empty);
            if (string.IsNullOrEmpty(userJson))
                return null;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<UserModel>(userJson, options);
        }

        public static void UserLogOut()
        {
            if(Preferences.Default.ContainsKey(UserLoggedKey))
            {
                Preferences.Default.Remove(UserLoggedKey);
            }
        }
    }
}
