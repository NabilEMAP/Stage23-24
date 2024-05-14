using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;
using System;

namespace PlanningsTool.DAL.Repositories
{
    public class TeamplansRepository : GenericRepository<Teamplan>, ITeamplansRepository
    {
        public TeamplansRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Teamplan>> GetAllTeamplansAsync()
        {
            return await _context.Teamplans.ToListAsync();
        }

        public async Task<Teamplan> GetTeamplanAsyncById(int id)
        {
            return await _context.Teamplans.FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<Teamplan>> GetTeamplansByName(string name)
        {
            return await _context.Teamplans
                .Where(z => z.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Teamplan>> GetTeamplansByPlanFor(string planFor)
        {
            return await _context.Teamplans
                .Where(z => z.PlanFor.ToString().Contains(planFor))
                .ToListAsync();
        }

        public async Task<IEnumerable<Teamplan>> GetTeamplansByCreatedOn(string createdOn)
        {
            return await _context.Teamplans
                .Where(z => z.CreatedOn.ToString().Contains(createdOn))
                .ToListAsync();
        }
    }
}
