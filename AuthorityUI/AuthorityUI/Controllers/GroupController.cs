﻿using System;
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
    public class GroupController : BaseController
    {
        /// <summary>
        /// 显示用户组列表信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string gname,string gdesc)
        {
            var groupService = new GroupService();
            if (gname == null)
            {
                var teams = groupService.GetAll();
                //访问数据库，获取一个用户组列表
                ViewData["Teams"] = teams;
            }
            else
            {
                var teams = groupService.GetGroupByName(gname);
                //访问数据库，获取一个用户组列表
                ViewData["Teams"] = teams;
            }
            
            return View();
        }
        /// <summary>
        /// 显示用户组明细信息
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail(Team team)
        {
            var groupService = new GroupService();
            var model = groupService.GetGroupById(team.Gid);
            return View(model);
        }
        public IActionResult Apoint(Team team)
        {
            var groupService = new GroupService();
            var model = groupService.GetGroupById(team.Gid);
            var gracService = new GracService();
            var gracs = gracService.GetAIdByGId(team.Gid);
            List<Author> accesslist = new List<Author>();
            var accessService = new AccessService();
            for (int i = 0; i < gracs.Count; i++)
            {
                var alist = accessService.GetAccessById(gracs[i].Aid.Value);
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
        public IActionResult AddGroup(Team team)
        {
            var groupService = new GroupService();
            var count = groupService.GroupAdd(team.Gname, team.Gdesc);
            return Redirect(Url.Action("Index", "Group"));//将数据返回主页列表
        }
        public IActionResult DeleteGroup(Team team)
        {
            var groupService = new GroupService();
            var teams = groupService.GroupDelete(team.Gid);
            return Redirect(Url.Action("Index", "Group"));
        }
        public IActionResult UpdateGroup(Team team)
        {
            var groupService = new GroupService();
            var ab = groupService.UpdateGroup(team.Gid, team.Gname, team.Gdesc);
            return Redirect(Url.Action("Index", "Group"));
        }
        public IActionResult GracDelete(Grac grac)
        {
            var gracService = new GracService();
            var gracs = gracService.GracDelete(grac);
            return Redirect("/Group/Apoint?gid=" + grac.Gid);
        }
        public IActionResult AddUnGrac(Grac grac)
        {
            var gracService = new GracService();
            var count = gracService.AddUnGrac(grac);
            return Redirect("/Group/Apoint?gid=" + grac.Gid);
        }
    }
}
