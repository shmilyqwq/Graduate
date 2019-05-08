//using Authority.Infrastructure.MyCourse;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Authority.DomainModel.Service
//{
//    public class HomeService
//    {
//        public User GetUserByEmail(string email,string password)
//        {
//            User user = null;
//            using (var dbContext = new AuthorityContext())
//            //DbContext实例化，用来执行GRUD操作
//            {
//                user = dbContext.User.FirstOrDefault(x => x.Email == email);
//                //取序列中满足条件的第一个元素，如果没有元素满足条件，则返回默认值
//                user = dbContext.User.FirstOrDefault(x => x.Password==password);
//            }
//            return user;
//        }
//    }
//}
