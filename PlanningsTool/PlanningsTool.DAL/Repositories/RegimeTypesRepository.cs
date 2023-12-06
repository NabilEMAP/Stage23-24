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
            return await _context.RegimeTypes
                .Where(z => z.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<RegimeType>> GetRegimeTypesByCountHours(string countHours)
        {
            return await _context.RegimeTypes
                .Where(z => z.CountHours.ToString().Contains(countHours))
                .ToListAsync();
        }
    }

}
