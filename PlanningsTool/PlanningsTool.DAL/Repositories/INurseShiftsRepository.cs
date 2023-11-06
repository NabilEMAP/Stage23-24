using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface INurseShiftsRepository : IGenericRepository<NurseShift> 
    { 
        Task<IEnumerable<NurseShift>> GetAllNurseShiftsAsync();
        Task<NurseShift> GetNurseShiftAsyncById(int id);
        Task<IEnumerable<NurseShift>> GetNurseShiftsByDate(string date);
    }
}
