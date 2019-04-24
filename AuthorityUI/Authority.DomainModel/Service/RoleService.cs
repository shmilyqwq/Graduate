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
        #endregion
    }
}



