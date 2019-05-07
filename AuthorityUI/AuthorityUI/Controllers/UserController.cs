using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorityUI.Models;
using Authority.Infrastructure.MyCourse;
using Authority.DomainModel;

namespace AuthorityUI.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 显示用户列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string uname, string email)
        {
            var userService = new UserService();
            if (uname == null)
            {
                var users = userService.GetAll();
                ViewData["Users"] = users;
            }
            else
            {
                var users = userService.GetUserByName(uname);
                ViewData["Users"] = users;
            }                       
            //访问数据库，获取一个用户列表
            //var users = new List<User>()
            //{
            //    new User(){Uid=1001,Uname="alam",Email="qjwew@163.com",Password="000000"},
            //    new User(){Uid=1002,Uname="scff",Email="xascz@163.com",Password="000000"}
            //};            
            return View();
        }
        /// <summary>
        /// 显示用户明细信息
        /// </summary>
        public IActionResult Detail(User user)
        {
            var userService = new UserService();
            var model = userService.GetUserById(user.Uid);
            return View(model);
        }        
        /// <summary>
        /// 分配角色
        /// </summary>
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult Group()
        {
            return View();
        }
        public IActionResult Apoint()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
        public IActionResult AddUser(User user)
        {
            var userService = new UserService();
            var count = userService.UserAdd(user.Uname, user.Email);
            return Redirect(Url.Action("Index", "User"));
        }
        public IActionResult DelUser(User user)
        {
            var userService = new UserService();
            var count= userService.UserDel(user.Uid);
            return Redirect(Url.Action("Index", "User"));
        }

        public IActionResult GetUserByName(User user)
        {
            var userService = new UserService();
            var users = userService.GetUserByName(user.Uname);
            ViewData["Users"] = users;
            return Redirect(Url.Action("Index", "User"));
        } 
        public IActionResult UpdateUser(User user)
        {
            var userService = new UserService();
            var ab = userService.UpdateUser(user.Uid,user.Uname, user.Email);
            return Redirect(Url.Action("Index", "User"));
        }
    }
}
