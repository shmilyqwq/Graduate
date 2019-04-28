using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Authority.Infrastructure.MyCourse;

namespace Authority.DomainModel
{
    public class RoleService
    {
        #region Action
        public List<Role> GetAll()
        {
            List<Role> roles = null;
            using (var dbContext = new AuthorityContext())
            {
                roles = dbContext.Role.ToList();
            }
            return roles;
        }

        public int RoleAdd(string rname, string rdesc)
        {
            int count = 0;
            var role = new Role()
            {
                Rname = rname,
                Rdesc = rdesc,                
            };
            using (var dbContext = new AuthorityContext())
            {
                dbContext.Role.Add(role);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        public Role RoleDelete(int rid)
        {
            Role role = new Role()
            {
                Rid = rid,
            };
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                role = dbContext.Role.FirstOrDefault(x => x.Rid == rid);
                dbContext.Role.Remove(role);
                dbContext.SaveChanges();
            }
            return role;
        }
        public List<Role> GetRoleByName(string rname)
        {
            List<Role> roles = null;
            using (var dbContext = new AuthorityContext())
            {
                roles = dbContext.Role.Where(x => x.Rname == rname).ToList();
            }
            return roles;
        }
        public Role GetRoleById(int rid)
        {
            Role role = null;
            using (var dbContext = new AuthorityContext())
            {
                role = dbContext.Role.FirstOrDefault(x => x.Rid == rid);
            }
            return role;
        }
        public string UpdateRole(int rid, string rname, string rdesc)
        {

            //标记为修改状态
            using (var dbContext = new AuthorityContext())
            {
                var role = dbContext.Role.FirstOrDefault(x => x.Rid == rid);
                role.Rname = rname;
                role.Rdesc = rdesc;
                dbContext.Role.Update(role);
                dbContext.SaveChanges();
            }
            return "修改成功！";
        }
        #endregion
    }
}



