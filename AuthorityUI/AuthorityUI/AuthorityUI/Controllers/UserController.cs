using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorityUI.Models;

namespace AuthorityUI.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 显示用户列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 显示用户明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 分配角色
        /// </summary>
        /// <returns></returns>
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
    }
}
