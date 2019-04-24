﻿using Authority.Infrastructure.MyCourse;
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
        #endregion
    }
}
