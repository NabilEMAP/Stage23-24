using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IShiftTypesRepository : IGenericRepository<ShiftType>
    {
        Task<IEnumerable<ShiftType>> GetShiftTypesByName(string name);
    }
}
