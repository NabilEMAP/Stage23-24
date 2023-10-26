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
    public class TeamplanningenRepository : GenericRepository<Teamplanning>, ITeamplanningenRepository
    {
        public TeamplanningenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Teamplanning>> GetTeamplanningenByMaand(string maand)
        {
            string query = $"SELECT * FROM [dbo].[Teamplanningen] AS z WHERE z.Maand like '%{maand}%'";
            return await _context.Teamplanningen.FromSqlRaw(query).ToListAsync();
        }
    }
}
