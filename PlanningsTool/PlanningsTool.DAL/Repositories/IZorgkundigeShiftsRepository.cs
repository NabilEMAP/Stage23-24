using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IZorgkundigeShiftsRepository : IGenericRepository<ZorgkundigeShift> 
    { 
        Task<IEnumerable<ZorgkundigeShift>> GetAllZorgkundigeShiftsAsync();
        Task<ZorgkundigeShift> GetZorgkundigeShiftAsyncById(int id);
        Task<IEnumerable<ZorgkundigeShift>> GetZorgkundigeShiftsByDatum(string datum);
    }
}
