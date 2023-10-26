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
    public class ZorgkundigeShiftsRepository : GenericRepository<ZorgkundigeShift>, IZorgkundigeShiftsRepository
    {
        public ZorgkundigeShiftsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ZorgkundigeShift>> GetAllZorgkundigeShiftsAsync()
        {
            return await _context.ZorgkundigeShifts
                .Include(z => z.Zorgkundige)
                .Include(s => s.Shift)
                .Include(t => t.Teamplanning)
                .ToListAsync();
        }

        public async Task<ZorgkundigeShift> GetZorgkundigeShiftAsyncById(int id)
        {
            return await _context.ZorgkundigeShifts
                .Include(z => z.Zorgkundige)
                .Include(s => s.Shift)
                .Include(t => t.Teamplanning)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<ZorgkundigeShift>> GetZorgkundigeShiftsByDatum(string datum)
        {
            string query = $"SELECT * FROM [dbo].[ZorgkundigeShifts] AS z WHERE z.Datum like '%{datum}%'";
            return await _context.ZorgkundigeShifts
                .FromSqlRaw(query)
                .Include(z => z.Zorgkundige)
                .Include(s => s.Shift)
                .Include(t => t.Teamplanning)
                .ToListAsync();
        }
    }
}
