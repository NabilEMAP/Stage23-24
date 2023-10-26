using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Shift>> GetShiftsByEindtijd(string eindtijd)
        {
            string query = $"SELECT * FROM [dbo].[Shifts] AS z WHERE z.Eindtijd like '%{eindtijd}%'";
            return await _context.Shifts.FromSqlRaw(query).Include(s => s.ShiftType).ToListAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsByStarttijd(string starttijd)
        {
            string query = $"SELECT * FROM [dbo].[Shifts] AS z WHERE z.Starttijd like '%{starttijd}%'";
            return await _context.Shifts.FromSqlRaw(query).Include(s => s.ShiftType).ToListAsync();
        }
    }
}
