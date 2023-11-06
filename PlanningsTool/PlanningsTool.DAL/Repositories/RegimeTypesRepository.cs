using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class RegimeTypesRepository : GenericRepository<RegimeType>, IRegimeTypesRepository
    {
        public RegimeTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegimeType>> GetRegimeTypesByName(string name)
        {
            string query = $"SELECT * FROM [dbo].[RegimeTypes] AS z WHERE z.Name like '%{name}%'";
            return await _context.RegimeTypes.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<RegimeType>> GetRegimeTypesByCountHours(string countHours)
        {
            string query = $"SELECT * FROM [dbo].[RegimeTypes] AS z WHERE z.CountHours like '%{countHours}%'";
            return await _context.RegimeTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
