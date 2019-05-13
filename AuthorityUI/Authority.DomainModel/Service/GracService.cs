using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class GracService
    {
        #region Action
        public List<Grac> GetAll()
        {
            List<Grac> gracs = null;
            using (var dbContext = new AuthorityContext())
            {
                gracs = dbContext.Grac.ToList();
            }
            return gracs;
        }
        public List<Grac> GetAIdByGId(int gid)
        {
            List<Grac> gracs = null;
            using (var dbContext=new AuthorityContext())
            {
                gracs = dbContext.Grac.Where(x => x.Gid == gid).ToList();
            }
            return gracs;
        }
        public Grac GracDelete(Grac grac)
        {
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                grac = dbContext.Grac.FirstOrDefault(x => x.Gid == grac.Gid && x.Aid == grac.Aid);
                dbContext.Grac.Remove(grac);
                dbContext.SaveChanges();
            }
            return grac;
        }
        public Grac AddUnGrac(Grac grac)
        {
            int count = 0;
            using (var dbcontext = new AuthorityContext())
            {

                dbcontext.Grac.Add(grac);
                count = dbcontext.SaveChanges();
            }
            return grac;
        }
        #endregion
    }
}
