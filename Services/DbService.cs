using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium_poprawa.DataAccess;
using Kolokwium_poprawa.Models.DTO;

namespace Kolokwium_poprawa.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SomeSortOfTeam>> GetTeam(int idTeam)
        {
            return await _dbContext.Teams.Where(t => t.TeamID == idTeam)
                                         .Select(e => new SomeSortOfTeam
                                         {
                                             TeamName = e.TeamName,
                                             TeamDescription = e.TeamDescription,
                                             OrganizationName = e.Organization.OrganizationName,
                                             /*Members = e.Memberships.Where(e =>e).Select(e => new TeamMember
                                             {
                                                 TeamID = e.TeamID,
                                                 MemberID = e.MemberID,
                                                 MembershipDate = e.MembershipDate
                                             }).OrderBy(e => e.MembershipDate).ToList()*/
                                             Members = e.Memberships.OrderBy(e => e.MembershipDate).ToList()
                                         }).ToList();
        }

    }
}
