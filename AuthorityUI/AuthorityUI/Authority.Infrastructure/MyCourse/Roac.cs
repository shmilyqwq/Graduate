using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class Roac
    {
        public int Rrid { get; set; }
        public int? Rid { get; set; }
        public int? Aid { get; set; }

        public virtual TbAccess A { get; set; }
        public virtual TbRole R { get; set; }
    }
}
