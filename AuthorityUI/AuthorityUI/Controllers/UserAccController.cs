using Authority.DomainModel;
using Authority.Infrastructure.MyCourse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityUI.Controllers
{
    public class UserAccController: BaseController
    {
        public IActionResult UserAccDelete(UserAcc useracc)
        {
            var useraccService = new UserAccService();
            var useraccs = useraccService.UserAccDelete(useracc);
            return Redirect("/User/Apoint?uid=" + useracc.Uid);
        }
        public IActionResult AddUnUserAcc(UserAcc useracc)
        {
            var useraccService = new UserAccService();
            var count = useraccService.AddUnUserAcc(useracc);
            return Redirect("/User/Apoint?uid=" + useracc.Uid);
        }
    }
}
