using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorityUI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Authority.DomainModel;
using Authority.Infrastructure.MyCourse;

namespace AuthorityUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
                              
            //return Redirect(Url.Action("Privacy", "Home"));
            return View();
        }

        public IActionResult Login(User tologin)
        {
            var userService = new UserService();
            var model = userService.GetUserByEmail(tologin.Email);
            var errorMsg = string.Empty;
            if (model == null || model.Password != tologin.Password)
            {
                errorMsg = "用户名或密码错误";
                return View("Index",errorMsg);
            }
           this.Response.Cookies.Append("user_id",model.Uid.ToString());
            return Redirect(Url.Action("Privacy", "Home"));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
