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
        public string RoleDelete(int rid)
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
            return "删除成功！";
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
        #endregion
    }
}



