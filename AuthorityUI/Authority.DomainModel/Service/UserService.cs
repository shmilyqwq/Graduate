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
        /// <summary>
        /// 获取列表信息
        /// </summary>
        public List<User> GetAll()
        {
            List<User> users = null;
            using (var dbContext = new AuthorityContext())
            {
                users = dbContext.User.ToList();
            }
            return users;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        public int UserAdd(string uname, string email)
        {
            int count = 0;
            var user = new User()
            {
                Uname = uname,
                Email = email,
                Password ="000000",
            };
            using (var dbContext = new AuthorityContext())
            {
                dbContext.User.Add(user);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int UserDel(int uid)
        {
            int count = 0;
            User user = new User()
            {
                Uid = uid,
            };
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
                dbContext.User.Remove(user);
                count=dbContext.SaveChanges();
                
            }
            return count;
        }
        /// <summary>
        /// 通过姓名查找用户
        /// </summary>
        public List<User> GetUserByName(string uname)
        {
            List<User> users=null;
            using (var dbContext = new AuthorityContext())
            {
                users = dbContext.User.Where(x=>x.Uname==uname).ToList();
            }
            return users;
        }
        /// <summary>
        /// 通过ID查找用户
        /// </summary>
        public User GetUserById(int uid)
        {
            User user = null;
            using (var dbContext = new AuthorityContext())
            {
                user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
                //取序列中满足条件的第一个元素，如果没有元素满足条件，则返回默认值
            }
            return user;
        }
        public User GetUserByEmail(string email)
        {
            User user = null;
            using (var dbContext = new AuthorityContext())
            //DbContext实例化，用来执行GRUD操作
            {
                user = dbContext.User.FirstOrDefault(x => x.Email == email);
                //取序列中满足条件的第一个元素，如果没有元素满足条件，则返回默认值
            }
            return user;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        public string UpdateUser(int uid,string uname,string email)
        {            
    
            //标记为修改状态
            using (var dbContext = new AuthorityContext())
            {
                var user = dbContext.User.FirstOrDefault(x => x.Uid == uid);
                user.Uname = uname;
                user.Email = email;
                dbContext.User.Update(user);
                dbContext.SaveChanges();//保存改变
            }
            return "修改成功！";
        }
        #endregion
    }
}
