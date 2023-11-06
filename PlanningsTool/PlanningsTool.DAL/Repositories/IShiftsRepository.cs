using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IShiftsRepository : IGenericRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift> GetShiftAsyncById(int id);
        Task<IEnumerable<Shift>> GetShiftsByStarttime(string starttime);
        Task<IEnumerable<Shift>> GetShiftsByEndtime(string endtime);
    }
}
