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
        public int UserAdd(string uname, string email)
        {
            var user = new TbUser()
            {
                Uname = uname,
                Email = email,
                Password = uname + "000000",
            };
            using (var dbContext = new MyauthorityContext())
            {
                dbContext.TbUser.Add(user);
                dbContext.SaveChanges();
            }
            return 1;
        }
        #endregion
    }
}
