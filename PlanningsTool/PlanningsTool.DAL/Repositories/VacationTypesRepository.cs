using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class VacationTypesRepository : GenericRepository<VacationType>, IVacationTypesRepository
    {
        public VacationTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VacationType>> GetVacationTypesByName(string name)
        {
            string query = $"SELECT * FROM [dbo].[VacationTypes] AS z WHERE z.Name like '%{name}%'";
            return await _context.VacationTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
