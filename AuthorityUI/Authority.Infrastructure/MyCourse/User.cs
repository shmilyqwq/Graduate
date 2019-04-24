using System;
using System.Collections.Generic;

namespace Authority.Infrastructure.MyCourse
{
    public partial class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
