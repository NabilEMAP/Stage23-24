using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class VacationsRepository : GenericRepository<Vacation>, IVacationsRepository
    {
        public VacationsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vacation>> GetAllVacationsAsync()
        {
            return await _context.Vacations
                .Include(v => v.VacationType)
                .Include(z => z.Nurse)
                .ToListAsync();
        }

        public async Task<Vacation> GetVacationAsyncById(int id)
        {
            return await _context.Vacations
                .Include(v => v.VacationType)
                .Include(z => z.Nurse)
                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<Vacation>> GetVacationsByStartdate(string startdate)
        {
            return await _context.Vacations
                .Where(z => z.Startdate.ToString().Contains(startdate))
                .Include(v => v.VacationType)
                .Include(z => z.Nurse)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vacation>> GetVacationsByEnddate(string enddate)
        {
            return await _context.Vacations
                .Where(z => z.Enddate.ToString().Contains(enddate))
                .Include(v => v.VacationType)
                .Include(z => z.Nurse)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vacation>> GetVacationsByReason(string reason)
        {
            return await _context.Vacations
                .Where(z => z.Reason.Contains(reason))
                .Include(v => v.VacationType)
                .Include(z => z.Nurse)
                .ToListAsync();
        }
    }
}