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
    public class GroupController : Controller
    {
        /// <summary>
        /// 显示用户组列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var groupService = new GroupService();
            var teams = groupService.GetAll();
            //访问数据库，获取一个用户组列表
            ViewData["Teams"] = teams;
            return View();
        }
        /// <summary>
        /// 显示用户组明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult AddGroup(Team team)
        {
            var groupService = new GroupService();
            var count = groupService.GroupAdd(team.Gname, team.Gdesc);
            return Redirect(Url.Action("Index", "Group"));//将数据返回主页列表
        }
    }
}
