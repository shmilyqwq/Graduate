using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthorityUI.Models;

namespace AuthorityUI.Controllers
{
    public class RoleController : Controller
    {
        /// <summary>
        /// 显示角色列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 显示角色明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Apoint()
        {
            return View();
        }

    }
}
