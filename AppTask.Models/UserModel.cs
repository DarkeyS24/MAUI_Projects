using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Models
{
    public  class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string AcccessToken { get; set; } = string.Empty;
        public DateTimeOffset AccessTokenCreated { get; set; }
        public DateTimeOffset UserCreated { get; set; }

        public ICollection<TaskModel>? Tasks { get; set; } = new List<TaskModel>();
    }
}
