using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class Grac
    {
        public int Grid { get; set; }
        public int? Aid { get; set; }
        public int? Gid { get; set; }

        public virtual TbAccess A { get; set; }
        public virtual TbGroup G { get; set; }
    }
}
