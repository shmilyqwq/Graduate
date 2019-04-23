using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class UserRole
    {
        public int Urid { get; set; }
        public int? Uid { get; set; }
        public int? Rid { get; set; }
        public int? Gid { get; set; }
        public int? Aid { get; set; }

        public virtual TbAccess A { get; set; }
        public virtual TbGroup G { get; set; }
        public virtual TbRole R { get; set; }
        public virtual TbUser U { get; set; }
    }
}
