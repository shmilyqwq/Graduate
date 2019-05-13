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
    public class AccessController : BaseController
    {
        /// <summary>
        /// 显示权限点列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string aname,int enabled)
        {
            var accessService = new AccessService();
            if (aname == null)
            {
                var authors = accessService.GetAll();
                //访问数据库，获取一个权限点列表
                ViewData["Authors"] = authors;
            }
            else
            {
                var authors = accessService.GetAccessByName(aname);
                //访问数据库，获取一个权限点
                ViewData["Authors"] = authors;
            }
            return View();
        }
        /// <summary>
        /// 显示权限点明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail(Author author)
        {
            var accessService = new AccessService();
            var model = accessService.GetAccessById(author.Aid);
            return View(model);
        }
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult AddAccess(Author author)
        {
            var accessService = new AccessService();
            var count = accessService.AccessAdd(author.Aname,(int)author.Enabled);
            return Redirect(Url.Action("Index", "Access"));
        }
        public IActionResult DeleteAccess(Author author)
        {
            var accessService = new AccessService();
            var authors = accessService.AccessDelete(author.Aid);
            return Redirect(Url.Action("Index", "Access"));
        }

        public IActionResult GetAccessByName(Author author)
        {
            var accessService = new AccessService();
            var authors = accessService.GetAccessByName(author.Aname);
            ViewData["Authors"] = authors;
            return Redirect(Url.Action("Index", "Access"));
        }
        public IActionResult UpdateAccess(Author author)
        {
            var accessService = new AccessService();
            var ab = accessService.UpdateAccess(author.Aid, author.Aname, (int)author.Enabled);
            return Redirect(Url.Action("Index", "Access"));
        }
    }
}
