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
    public class VerlofTypesRepository : GenericRepository<VerlofType>, IVerlofTypesRepository
    {
        public VerlofTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VerlofType>> GetVerlofTypesByNaam(string naam)
        {
            string query = $"SELECT * FROM [dbo].[VerlofTypes] AS z WHERE z.Verlof like '%{naam}%'";
            return await _context.VerlofTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
