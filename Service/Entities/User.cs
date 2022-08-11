using Service.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Entities
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public USER_ROLE RoleId { get; set; }
        public string? FacebookId { get; set; }
    }
}
