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
            string query = $"SELECT * FROM [dbo].[Vacations] AS z WHERE z.Startdate like '%{startdate}%'";
            return await _context.Vacations.FromSqlRaw(query).Include(v => v.VacationType)
                .Include(z => z.Nurse).ToListAsync();
        }

        public async Task<IEnumerable<Vacation>> GetVacationsByEnddate(string enddate)
        {
            string query = $"SELECT * FROM [dbo].[Vacations] AS z WHERE z.Enddate like '%{enddate}%'";
            return await _context.Vacations.FromSqlRaw(query).Include(v => v.VacationType)
                .Include(z => z.Nurse).ToListAsync();
        }

        public async Task<IEnumerable<Vacation>> GetVacationsByReason(string reason)
        {
            string query = $"SELECT * FROM [dbo].[Vacations] AS z WHERE z.Reason like '%{reason}%'";
            return await _context.Vacations.FromSqlRaw(query).Include(v => v.VacationType)
                .Include(z => z.Nurse).ToListAsync();
        }


    }
}