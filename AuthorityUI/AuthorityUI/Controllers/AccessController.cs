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
    public class AccessController : Controller
    {
        /// <summary>
        /// 显示权限点列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var accessService = new AccessService();
            var authors = accessService.GetAll();
            //访问数据库，获取一个权限点列表
            ViewData["Authors"] = authors;
            return View();
        }
        /// <summary>
        /// 显示权限点明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult AddAccess(Author author)
        {
            var accessService = new AccessService();
            var count = accessService.AccessAdd(author.Aname, author.Enabled);
            return Redirect(Url.Action("Index", "Access"));
        }
    }
}
