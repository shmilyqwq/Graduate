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

        public string UserDel(int uid)
        {
            User user = new User()
            {
                Uid = uid,
            };
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
                dbContext.User.Remove(user);
                dbContext.SaveChanges();
            }
            return "删除成功！";
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
        public User GetUserById(int uid)
        {
            User user = null;
            using (var dbContext = new AuthorityContext())
            {
                user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
            }
            return user;
        }
        public string UpdateUser(int uid,string uname,string email)
        {            
    
            //标记为修改状态
            using (var dbContext = new AuthorityContext())
            {
                var user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
                user.Uname = uname;
                user.Email = email;
                dbContext.User.Update(user);
                dbContext.SaveChanges();
            }
            return "修改成功！";
        }
        #endregion
    }
}
