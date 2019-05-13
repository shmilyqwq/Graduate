using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class UserAccService
    {
        #region Action
        public List<UserAcc> GetAll()
        {
            List<UserAcc> useraccs = null;
            using (var dbContext = new AuthorityContext())
            {
                useraccs = dbContext.UserAcc.ToList();
            }
            return useraccs;
        }
        public List<UserAcc> GetAIdByUId(int uid)
        {
            List<UserAcc> useraccs = null;
            using (var dbContext = new AuthorityContext())
            {
                useraccs = dbContext.UserAcc.Where(x => x.Uid == uid).ToList();
            }
            return useraccs;
        }
        public UserAcc UserAccDelete(UserAcc useracc)
        {
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                useracc = dbContext.UserAcc.FirstOrDefault(x => x.Uid == useracc.Uid && x.Aid == useracc.Aid);
                dbContext.UserAcc.Remove(useracc);
                dbContext.SaveChanges();
            }
            return useracc;
        }
        public UserAcc AddUnUserAcc(UserAcc useracc)
        {
            int count = 0;
            using (var dbcontext = new AuthorityContext())
            {

                dbcontext.UserAcc.Add(useracc);
                count = dbcontext.SaveChanges();
            }
            return useracc;
        }
        #endregion
    }
}
