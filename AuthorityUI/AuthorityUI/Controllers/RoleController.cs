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
    public class RoleController : BaseController
    {
        /// <summary>
        /// 显示角色列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string rname,string rdesc)
        {
            var roleService = new RoleService();
            if (rname == null)
            {
                var roles = roleService.GetAll();
                //访问数据库，获取一个角色列表            
                ViewData["Roles"] = roles;
            }
            else
            {
                var roles = roleService.GetRoleByName(rname);
                ViewData["Roles"] = roles;
            }
            return View();
        }
        /// <summary>
        /// 显示角色明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail(Role role)
        {
            var roleService = new RoleService();
            var model = roleService.GetRoleById(role.Rid);
            return View(model);
        }
        public IActionResult Apoint(Role role)
        {
            var roleService = new RoleService();
            var model = roleService.GetRoleById(role.Rid);
            var roleaccService = new RoleAccService();
            var roacs = roleaccService.GetAIdByRId(role.Rid);
            List<Author> accesslist =new List<Author>();
            var accessService = new AccessService();
            for (int i = 0; i < roacs.Count; i++)
            {
                var alist= accessService.GetAccessById((int)roacs[i].Aid);
                accesslist.Add(alist);
            }
            ViewData["Authors"] = accesslist;
            

            var allAccessList = accessService.GetAll();
            var unAuthorList = new List<Author>();

            foreach (var author in allAccessList)
            {
                var isAdd = !accesslist.Exists(x => x.Aid == author.Aid);
                if (isAdd)
                {
                    unAuthorList.Add(author);
                }
            }
            ViewData["UnAuthorList"] = unAuthorList;
            return View(model);
        }
        //public IActionResult Roac(Roac roac)
        //{
        //    var roleaccService = new RoleAccService();
        //    roac.Rid = 1;
        //    var model = roleaccService.GetAccessByRId((int)roac.Rid);
        //    return View(model);
        //}
        public IActionResult AddRole(Roac roac)
        {
            var roacService = new RoleAccService();
            
            var count = roacService.AddRoac(roac);
            return Redirect(Url.Action("Index", "Role"));
        }
        public IActionResult RoleDelete(Role role)
        {
            var roleService = new RoleService();
            var roles = roleService.RoleDelete(role.Rid);
            return Redirect(Url.Action("Index", "Role"));
        }
        public IActionResult UpdateRole(Role role)
        {
            var roleService = new RoleService();
            var ab = roleService.UpdateRole(role.Rid, role.Rname, role.Rdesc);
            return Redirect(Url.Action("Index", "Role"));
        }
        public IActionResult RoacDelete(Roac roac)
        {
            var roleaccService = new RoleAccService();
            var roles = roleaccService.RoacDelete(roac);
            return Redirect("/Role/Apoint?rid="+roac.Rid);
        }
        public IActionResult AddUnRoac(Roac roac)
        {
            var roleaccService = new RoleAccService();
            var count = roleaccService.AddUnRoac(roac);
            return Redirect("/Role/Apoint?rid=" + roac.Rid);
        }
        //public IActionResult ListRoac(Roac roac)
        //{
        //    var roleaccService = new RoleAccService();
        //    var rlist = roleaccService.GetAccessByRId(roac.Rid);
        //    return Redirect(Url.Action("Index", "Role"));
        //}
    }
}
