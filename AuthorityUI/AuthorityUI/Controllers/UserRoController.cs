using Authority.DomainModel;
using Authority.Infrastructure.MyCourse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityUI.Controllers
{
    public class UserRoController:BaseController
    {
        public IActionResult UserRoDelete(UserRo usero)
        {
            var userroService = new UserRoService();
            var useros = userroService.UserRoDelete(usero);
            return Redirect("/User/Role?uid=" + usero.Uid);
        }
        public IActionResult AddUnUserRo(UserRo usero)
        {
            var userroService = new UserRoService();
            var count = userroService.AddUnUserRo(usero);
            return Redirect("/User/Role?uid=" + usero.Uid);
        }
    }
}
