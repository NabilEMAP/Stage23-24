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
            string query = $"SELECT * FROM [dbo].[Nurses] AS z WHERE z.LastName like '%{lastName}%'";
            return await _context.Nurses.FromSqlRaw(query).Include(r => r.RegimeType).ToListAsync();
        }

        public async Task<IEnumerable<Nurse>> GetNursesByFirstName(string firstName)
        {
            string query = $"SELECT * FROM [dbo].[Nurses] AS z WHERE z.FirstName like '%{firstName}%'";
            return await _context.Nurses.FromSqlRaw(query).Include(r => r.RegimeType).ToListAsync();
        }
    }
}
