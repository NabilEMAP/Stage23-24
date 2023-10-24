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
    public class ShiftTypesRepository : GenericRepository<ShiftType>, IShiftTypesRepository
    {
        public ShiftTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ShiftType>> GetShiftTypesByNaam(string naam)
        {
            string query = $"SELECT * FROM [dbo].[ShiftTypes] AS z WHERE z.Shift like '%{naam}%'";
            return await _context.ShiftTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
