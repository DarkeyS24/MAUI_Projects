using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Libraries.NovaPasta
{
    public class EmailValidate
    {

        public static bool IsValidEmail(string? trimmedEmail)
        {
            if (trimmedEmail == null)
            {
                return false;
            }
            else if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(trimmedEmail);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
