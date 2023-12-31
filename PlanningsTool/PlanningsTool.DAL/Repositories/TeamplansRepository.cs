﻿using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class TeamplansRepository : GenericRepository<Teamplan>, ITeamplansRepository
    {
        public TeamplansRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Teamplan>> GetTeamplansByMonth(string month)
        {
            return await _context.Teamplans
                .Where(z => z.Month.ToString().Contains(month))
                .ToListAsync();
        }
    }

}
