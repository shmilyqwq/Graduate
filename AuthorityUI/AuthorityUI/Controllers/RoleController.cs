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
    public class RoleController : Controller
    {
        /// <summary>
        /// 显示角色列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var roleService = new RoleService();
            var roles = roleService.GetAll();
            //访问数据库，获取一个角色列表            
            ViewData["Roles"] = roles;
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
        public IActionResult AddRole(Role role)
        {
            var roleService = new RoleService();
            var count = roleService.RoleAdd(role.Rname, role.Rdesc);
            return Redirect(Url.Action("Index", "Role"));
        }

    }
}
