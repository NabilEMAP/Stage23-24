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
    public class VerlovenRepository : GenericRepository<Verlof>, IVerlovenRepository
    {
        public VerlovenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Verlof>> GetAllVerlovenAsync()
        {
            return await _context.Verloven
                .Include(v => v.VerlofType)
                .Include(z => z.Zorgkundige)
                .ToListAsync();
        }

        public async Task<IEnumerable<Verlof>> GetVerlovenByStartdatum(string startdatum)
        {
            string query = $"SELECT * FROM [dbo].[Verloven] AS z WHERE z.Startdatum like '%{startdatum}%'";
            return await _context.Verloven.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Verlof>> GetVerlovenByEinddatum(string einddatum)
        {
            string query = $"SELECT * FROM [dbo].[Verloven] AS z WHERE z.Einddatum like '%{einddatum}%'";
            return await _context.Verloven.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Verlof>> GetVerlovenByReden(string reden)
        {
            string query = $"SELECT * FROM [dbo].[Verloven] AS z WHERE z.Reden like '%{reden}%'";
            return await _context.Verloven.FromSqlRaw(query).ToListAsync();
        }

        
    }
}
