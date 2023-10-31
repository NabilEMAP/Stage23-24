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
    public class FeestdagenRepository : GenericRepository<Feestdag>, IFeestdagenRepository
    {
        public FeestdagenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddFeestdagenByJaar(int jaar)
        {
            List<Feestdag> feestdagen = new List<Feestdag>
            {
                // Voeg feestdagen voor het opgegeven jaar toe aan de lijst
                new Feestdag { Naam = "Pasen", Datum = Feestdag.BerekenPasen(jaar) },
                new Feestdag { Naam = "Paasmaandag", Datum = Feestdag.BerekenPaasmaandag(jaar) },
                new Feestdag { Naam = "Pinksteren", Datum = Feestdag.BerekenPinksteren(jaar) },
                new Feestdag { Naam = "Pinkstermaandag", Datum = Feestdag.BerekenPinkstermaandag(jaar) },
                new Feestdag { Naam = "O.L.H. Hemelvaart", Datum = Feestdag.BerekenOLHHemelvaart(jaar) },
                new Feestdag { Naam = "Nieuwjaar", Datum = Feestdag.Nieuwjaar(jaar) },
                new Feestdag { Naam = "Dag van de arbeid", Datum = Feestdag.DagVdArbeid(jaar) },
                new Feestdag { Naam = "Nationale feestdag", Datum = Feestdag.NationaleFeestdag(jaar) },
                new Feestdag { Naam = "O.L.V. Hemelvaart", Datum = Feestdag.OLVHemelvaart(jaar) },
                new Feestdag { Naam = "Allerheiligen", Datum = Feestdag.Allerheiligen(jaar) },
                new Feestdag { Naam = "Wapenstilstand", Datum = Feestdag.Wapenstilstand(jaar) },
                new Feestdag { Naam = "Kermis", Datum = Feestdag.Kermis(jaar) }
            };

            // Voeg de lijst van feestdagen toe aan de database
            await _context.Feestdagen.AddRangeAsync(feestdagen);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Feestdag>> GetFeestdagenByNaam(string naam)
        {
            string query = $"SELECT * FROM [dbo].[Feestdagen] AS z WHERE z.Naam like '%{naam}%'";
            return await _context.Feestdagen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Feestdag>> GetFeestdagenByDatum(string datum)
        {
            string query = $"SELECT * FROM [dbo].[Feestdagen] AS z WHERE z.Datum like '%{datum}%'";
            return await _context.Feestdagen.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Feestdag>> GetFeestdagByJaar(int jaar)
        {
            string query = $"SELECT * FROM [dbo].[Feestdagen] AS z WHERE YEAR(z.Datum) like '{jaar}'";
            return await _context.Feestdagen.FromSqlRaw(query).ToListAsync();
            throw new NotImplementedException();
        }
    }
}
