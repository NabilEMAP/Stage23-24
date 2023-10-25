using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IShiftsRepository : IGenericRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift> GetShiftAsyncById(int id);
        Task<IEnumerable<Shift>> GetShiftsByStarttijd(string starttijd);
        Task<IEnumerable<Shift>> GetShiftsByEindtijd(string starttijd);
    }
}
