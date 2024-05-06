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

        public async Task<IEnumerable<VacationType>> GetAllVacationTypesAsync()
        {
            return await _context.VacationTypes.ToListAsync();
        }

        public async Task<VacationType> GetVacationTypeAsyncById(int id)
        {
            return await _context.VacationTypes.FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<VacationType>> GetVacationTypesByName(string name)
        {
            return await _context.VacationTypes
                .Where(z => z.Name.Contains(name))
                .ToListAsync();
        }
    }
}
