using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class NursesRepository : GenericRepository<Nurse>, INursesRepository
    {
        public NursesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _context.Nurses
                .Include(r => r.RegimeType)
                .ToListAsync();
        }

        public async Task<Nurse> GetNurseAsyncById(int id)
        {
            return await _context.Nurses
                .Include(r => r.RegimeType)
                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<Nurse>> GetNursesByLastName(string lastName)
        {
            return await _context.Nurses
                .Where(z => z.LastName.Contains(lastName))
                .Include(r => r.RegimeType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Nurse>> GetNursesByFirstName(string firstName)
        {
            return await _context.Nurses
                .Where(z => z.FirstName.Contains(firstName))
                .Include(r => r.RegimeType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Nurse>> GetNursesByFullName(string fullName)
        {
            return await _context.Nurses
                .Where(z => string.Concat(z.FirstName, z.LastName) == fullName)
                .Include(r => r.RegimeType)
                .ToListAsync();
        }
    }
}
