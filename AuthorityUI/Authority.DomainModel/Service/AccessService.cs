using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class AccessService
    {
        #region Action
        public List<Author> GetAll()
        {
            List<Author> authors = null;
            using (var dbContext = new AuthorityContext())
            {
                authors = dbContext.Author.ToList();
            }
            return authors;
        }
        public int AccessAdd(string aname, int enabled)
        {
            int count = 0;
            var author = new Author()
            {
                Aname = aname,
                Enabled = enabled,
            };
            using (var dbContext = new AuthorityContext())
            {
                dbContext.Author.Add(author);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        public Author AccessDelete(int aid)
        {
            Author author = new Author()
            {
                Aid = aid,
            };
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                author = dbContext.Author.FirstOrDefault(x => x.Aid == aid);
                dbContext.Author.Remove(author);
                dbContext.SaveChanges();
            }
            return author;
        }
        public List<Author> GetAccessByName(string aname)
        {
            List<Author> authors = null;
            using (var dbContext = new AuthorityContext())
            {
                authors = dbContext.Author.Where(x => x.Aname == aname).ToList();
            }
            return authors;
        }

        public Author GetAccessById(int aid)
        {
            Author author = null;
            using (var dbContext = new AuthorityContext())
            {
                author = dbContext.Author.FirstOrDefault(x => x.Aid == aid);
            }
            return author;
        }
        public string UpdateAccess(int aid, string aname, int enabled)
        {

            //标记为修改状态
            using (var dbContext = new AuthorityContext())
            {
                var author = dbContext.Author.FirstOrDefault(x => x.Aid == aid);
                author.Aname = aname;
                author.Enabled = enabled;
                dbContext.Author.Update(author);
                dbContext.SaveChanges();
            }
            return "修改成功！";
        }

        #endregion
    }
}
