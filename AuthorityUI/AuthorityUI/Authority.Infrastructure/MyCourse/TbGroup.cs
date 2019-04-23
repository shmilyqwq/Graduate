using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class TbGroup
    {
        public TbGroup()
        {
            Grac = new HashSet<Grac>();
            UserRole = new HashSet<UserRole>();
        }

        public int Gid { get; set; }
        public string Gname { get; set; }
        public string Gdesc { get; set; }

        public virtual ICollection<Grac> Grac { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
