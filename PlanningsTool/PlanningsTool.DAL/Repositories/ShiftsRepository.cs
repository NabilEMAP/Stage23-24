using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class ShiftsRepository : GenericRepository<Shift>, IShiftsRepository
    {
        public ShiftsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await _context.Shifts
                .Include(s => s.ShiftType)
                .ToListAsync();
        }

        public async Task<Shift> GetShiftAsyncById(int id)
        {
            return await _context.Shifts
                .Include(s => s.ShiftType)
                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<Shift>> GetShiftsByEndtime(string endtime)
        {
            return await _context.Shifts
                .Include(s => s.ShiftType)
                .Where(z => z.Endtime.ToString().Contains(endtime))
                .ToListAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsByStarttime(string starttime)
        {
            return await _context.Shifts
                .Include(s => s.ShiftType)
                .Where(z => z.Starttime.ToString().Contains(starttime))
                .ToListAsync();
        }
    }

}
