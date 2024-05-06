using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
    {
        public TeamsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Team>> GetTeamsByTeamName(string teamName)
        {
            return await _context.Teams
                .Where(z => z.TeamName.ToString().Contains(teamName))
                .ToListAsync();
        }
    }
}