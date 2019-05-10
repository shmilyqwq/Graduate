using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorityUI.Models;
using Authority.DomainModel;
using Authority.Infrastructure.MyCourse;

namespace AuthorityUI.Controllers
{
    public class BaseController:Controller
    {
        public IActionResult Verify()
        {
            var cookie = Request.Cookies["user_id"];
            if (cookie == null)
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(Url.Action("Privacy", "Home"));
        }
    }
}
