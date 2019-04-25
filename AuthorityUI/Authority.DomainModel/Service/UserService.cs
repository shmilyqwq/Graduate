using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Authority.Infrastructure.MyCourse;

namespace Authority.DomainModel
{
    public class UserService
    {
        #region Action
        public List<User> GetAll()
        {
            List<User> users = null;
            using (var dbContext = new AuthorityContext())
            {
                users = dbContext.User.ToList();
            }
            return users;
        }

        public int UserAdd(string uname, string email)
        {
            int count = 0;
            var user = new User()
            {
                Uname = uname,
                Email = email,
                Password = uname + "000000",
            };
            using (var dbContext = new AuthorityContext())
            {
                dbContext.User.Add(user);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        public List<User> GetUserByName(string uname)
        {
            List<User> users=null;
            using (var dbContext = new AuthorityContext())
            {
                users = dbContext.User.Where(x=>x.Uname==uname).ToList();
            }
            return users;
        }
        #endregion
    }
}
