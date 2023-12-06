using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class HolidaysRepository : GenericRepository<Holiday>, IHolidaysRepository
    {
        public HolidaysRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddHolidaysByYear(int year)
        {
            List<Holiday> holidays = new List<Holiday>
            {
                // Voeg feestdagen voor het opgegeven jaar toe aan de lijst
                new Holiday { Name = "Pasen", Date = Holiday.CalculateEaster(year) },
                new Holiday { Name = "Paasmaandag", Date = Holiday.CalculateEastermonday(year) },
                new Holiday { Name = "Pinksteren", Date = Holiday.CalculatePinksteren(year) },
                new Holiday { Name = "Pinkstermaandag", Date = Holiday.CalculatePinkstermonday(year) },
                new Holiday { Name = "O.L.H. Hemelvaart", Date = Holiday.CalculateOLHHemelvaart(year) },
                new Holiday { Name = "Nieuwjaar", Date = Holiday.Newyear(year) },
                new Holiday { Name = "Dag van de arbeid", Date = Holiday.DagVdArbeid(year) },
                new Holiday { Name = "Nationale feestdag", Date = Holiday.NationalHoliday(year) },
                new Holiday { Name = "O.L.V. Hemelvaart", Date = Holiday.OLVHemelvaart(year) },
                new Holiday { Name = "Allerheiligen", Date = Holiday.Allerheiligen(year) },
                new Holiday { Name = "Wapenstilstand", Date = Holiday.Wapenstilstand(year) },
                new Holiday { Name = "Kermis", Date = Holiday.Christmas(year) }
            };

            // Voeg de lijst van feestdagen toe aan de database
            await _context.Holidays.AddRangeAsync(holidays);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Holiday>> GetHolidaysByName(string name)
        {
            return await _context.Holidays
                .Where(z => z.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysByDate(string date)
        {
            return await _context.Holidays
                .Where(z => z.Date.ToString().Contains(date))
                .ToListAsync();
        }

        public async Task<IEnumerable<Holiday>> GetHolidayByYear(int year)
        {
            return await _context.Holidays
                .Where(z => z.Date.Year == year)
                .ToListAsync();
        }

    }
}
