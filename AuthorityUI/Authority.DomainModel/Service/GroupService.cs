using Authority.Infrastructure.MyCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authority.DomainModel
{
    public class GroupService
    {
        #region Action
        public List<Team> GetAll()
        {
            List<Team> teams = null;
            using (var dbContext = new AuthorityContext())
            {
                teams = dbContext.Team.ToList();
            }
            return teams;
        }
        public int GroupAdd(string gname, string gdesc)
        {
            int count = 0;
            var team = new Team()
            {
                Gname = gname,
                Gdesc = gdesc,
            };
            using (var dbContext = new AuthorityContext())
            {
                dbContext.Team.Add(team);
                count = dbContext.SaveChanges();
            }
            return count;
        }
        public Team GroupDelete(int gid)
        {
            Team team = new Team()
            {
                Gid = gid,
            };
            //标记为删除状态
            using (var dbContext = new AuthorityContext())
            {
                team = dbContext.Team.FirstOrDefault(x => x.Gid == gid);
                dbContext.Team.Remove(team);
                dbContext.SaveChanges();
            }
            return team;
        }
        #endregion
    }
}
