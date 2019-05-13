using Authority.DomainModel;
using Authority.Infrastructure.MyCourse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityUI.Controllers
{
    public class UserTeController:BaseController
    {
        /// <summary>
        /// 分配用户组
        /// </summary>
        /// <param name="userte"></param>
        /// <returns></returns>
        public IActionResult UserTeDelete(UserTe userte)
        {
            var userteService = new UserTeService();
            var usetes = userteService.UserTeDelete(userte);
            return Redirect("/User/Group?uid=" + userte.Uid);
        }
        public IActionResult AddUnUserTe(UserTe userte)
        {
            var userteService = new UserTeService();
            var count = userteService.AddUnUserTe(userte);
            return Redirect("/User/Group?uid=" + userte.Uid);
        }
    }
}
