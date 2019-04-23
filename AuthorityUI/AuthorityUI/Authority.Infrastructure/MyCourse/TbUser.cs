using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class TbUser
    {
        public TbUser()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
