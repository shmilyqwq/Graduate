using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class RoleAccService
    {
        #region Action
        public List<Roac> GetAll()
        {
            List<Roac> roacs = null;
            using (var dbContext = new AuthorityContext())
            {
                roacs = dbContext.Roac.ToList();
            }
            return roacs;
        }
        public int AddRoac(Roac roac)
        {
            int count = 0;
            using(var dbcontext=new AuthorityContext())
            {
                dbcontext.Roac.Add(roac);
                count = dbcontext.SaveChanges();
            }
            return count;
        }
        public List<Roac> GetAIdByRId(int rid)
        {
            List<Roac> roacs = null;
           
            using (var dbContext = new AuthorityContext())
            {
                roacs = dbContext.Roac.Where(x => x.Rid == rid).ToList();
                
            }
            return roacs;
        }
    }
    #endregion
}
