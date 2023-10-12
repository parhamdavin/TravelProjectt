using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Domain.User
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Userr User { get; set; }
        public virtual Roles Role { get; set; }
    }
}
