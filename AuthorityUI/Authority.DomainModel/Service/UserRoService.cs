using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class UserRoService
    {
        #region Action
        public List<UserRo> GetAll()
        {
            List<UserRo> useros = null;
            using (var dbContext = new AuthorityContext())
            {
                useros = dbContext.UserRo.ToList();
            }
            return useros;
        }
        public List<UserRo> GetRIdByUId(int uid)
        {
            List<UserRo> useros = null;
            using (var dbContext = new AuthorityContext())
            {
                useros = dbContext.UserRo.Where(x => x.Uid == uid).ToList();
            }
            return useros;
        }
        public UserRo UserRoDelete(UserRo usero)
        {
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                usero = dbContext.UserRo.FirstOrDefault(x => x.Uid == usero.Uid && x.Rid == usero.Rid);
                dbContext.UserRo.Remove(usero);
                dbContext.SaveChanges();
            }
            return usero;
        }
        public UserRo AddUnUserRo(UserRo usero)
        {
            int count = 0;
            using (var dbcontext = new AuthorityContext())
            {

                dbcontext.UserRo.Add(usero);
                count = dbcontext.SaveChanges();
            }
            return usero;
        }
        #endregion
    }
}
