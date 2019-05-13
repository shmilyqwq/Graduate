using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class UserTeService
    {
        #region Action
        public List<UserTe> GetAll()
        {
            List<UserTe> usetes = null;
            using (var dbContext = new AuthorityContext())
            {
                usetes = dbContext.UserTe.ToList();
            }
            return usetes;
        }
        public List<UserTe> GetGIdByUId(int uid)
        {
            List<UserTe> usetes = null;
            using (var dbContext = new AuthorityContext())
            {
                usetes = dbContext.UserTe.Where(x => x.Uid == uid).ToList();
            }
            return usetes;
        }
        public UserTe UserTeDelete(UserTe usete)
        {
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                usete = dbContext.UserTe.FirstOrDefault(x => x.Uid == usete.Uid && x.Gid == usete.Gid);
                dbContext.UserTe.Remove(usete);
                dbContext.SaveChanges();
            }
            return usete;
        }
        public UserTe AddUnUserTe(UserTe usete)
        {
            int count = 0;
            using (var dbcontext = new AuthorityContext())
            {

                dbcontext.UserTe.Add(usete);
                count = dbcontext.SaveChanges();
            }
            return usete;
        }
        #endregion
    }
}
