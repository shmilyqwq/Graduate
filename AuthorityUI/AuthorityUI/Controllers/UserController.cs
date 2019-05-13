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
    public class UserController : BaseController
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
        public IActionResult Role(User user)
        {
            var userService = new UserService();
            var model = userService.GetUserById(user.Uid);
            var userroService = new UserRoService();
            var useros = userroService.GetRIdByUId(user.Uid);
            List<Role> rolelist = new List<Role>();
            var roleService = new RoleService();
            for (int i = 0; i < useros.Count; i++)
            {
                var rlist = roleService.GetRoleById((int)useros[i].Rid);
                rolelist.Add(rlist);
            }
            ViewData["Roles"] = rolelist;


            var allRoleList = roleService.GetAll();
            var unRoleList = new List<Role>();

            foreach (var role in allRoleList)
            {
                var isAdd = !rolelist.Exists(x => x.Rid == role.Rid);
                if (isAdd)
                {
                    unRoleList.Add(role);
                }
            }
            ViewData["UnRoleList"] = unRoleList;
            return View(model);
        }
        /// <summary>
        /// 分配用户组
        /// </summary>
        /// <returns></returns>
        public IActionResult Group(User user)
        {
            var userService = new UserService();
            var model = userService.GetUserById(user.Uid);
            var userteService = new UserTeService();
            var usertes = userteService.GetGIdByUId(user.Uid);
            List<Team> grouplist = new List<Team>();
            var groupService = new GroupService();
            for (int i = 0; i < usertes.Count; i++)
            {
                var glist = groupService.GetGroupById((int)usertes[i].Gid);
                grouplist.Add(glist);
            }
            ViewData["Teams"] = grouplist;


            var allGroupList = groupService.GetAll();
            var unTeamList = new List<Team>();

            foreach (var team in allGroupList)
            {
                var isAdd = !grouplist.Exists(x => x.Gid == team.Gid);
                if (isAdd)
                {
                    unTeamList.Add(team);
                }
            }
            ViewData["UnTeamList"] = unTeamList;
            return View(model);
        }
        /// <summary>
        /// 分配权限点
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IActionResult Apoint(User user)
        {
            var userService = new UserService();
            var model = userService.GetUserById(user.Uid);
            var useraccService = new UserAccService();
            var useraccs = useraccService.GetAIdByUId(user.Uid);
            List<Author> accesslist = new List<Author>();
            var accessService = new AccessService();
            for (int i = 0; i < useraccs.Count; i++)
            {
                var alist = accessService.GetAccessById((int)useraccs[i].Aid);
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
