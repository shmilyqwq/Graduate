using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class TbRole
    {
        public TbRole()
        {
            Roac = new HashSet<Roac>();
            UserRole = new HashSet<UserRole>();
        }

        public int Rid { get; set; }
        public string Rname { get; set; }
        public string Rdesc { get; set; }

        public virtual ICollection<Roac> Roac { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
