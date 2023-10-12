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
    public class ZorgkundigenRepository : GenericRepository<Zorgkundige>, IZorgkundigenRepository
    {
        public ZorgkundigenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Zorgkundige>> GetZorgkundigenByAchternaam(string achternaam)
        {
            string query = $"SELECT * FROM [Zorgkundige].[tblZorgkundigen] AS z WHERE z.Achternaam like '%{achternaam}%'";
            return await _context.Zorgkundigen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Zorgkundige>> GetZorgkundigenByVoornaam(string voornaam)
        {
            string query = $"SELECT * FROM [Zorgkundige].[tblZorgkundigen] AS z WHERE z.Voornaam like '%{voornaam}%'";
            return await _context.Zorgkundigen.FromSqlRaw(query).ToListAsync();
        }
    }
}
