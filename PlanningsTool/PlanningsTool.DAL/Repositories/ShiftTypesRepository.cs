using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class ShiftTypesRepository : GenericRepository<ShiftType>, IShiftTypesRepository
    {
        public ShiftTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShiftType>> GetShiftTypesByName(string name)
        {
            string query = $"SELECT * FROM [dbo].[ShiftTypes] AS z WHERE z.Name like '%{name}%'";
            return await _context.ShiftTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
