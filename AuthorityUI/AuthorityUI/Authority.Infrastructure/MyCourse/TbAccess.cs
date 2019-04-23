using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class TbAccess
    {
        public TbAccess()
        {
            Grac = new HashSet<Grac>();
            Roac = new HashSet<Roac>();
            UserRole = new HashSet<UserRole>();
        }

        public int Aid { get; set; }
        public string Aname { get; set; }
        public sbyte? Enabled { get; set; }

        public virtual ICollection<Grac> Grac { get; set; }
        public virtual ICollection<Roac> Roac { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
