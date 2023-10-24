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
    public class RegimeTypesRepository : GenericRepository<RegimeType>, IRegimeTypesRepository
    {
        public RegimeTypesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegimeType>> GetRegimeTypesByNaam(string naam)
        {
            string query = $"SELECT * FROM [dbo].[RegimeTypes] AS z WHERE z.Regime like '%{naam}%'";
            return await _context.RegimeTypes.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<RegimeType>> GetRegimeTypesByAantalUren(string aantalUren)
        {
            string query = $"SELECT * FROM [dbo].[RegimeTypes] AS z WHERE z.AantalUren like '%{aantalUren}%'";
            return await _context.RegimeTypes.FromSqlRaw(query).ToListAsync();
        }
    }
}
