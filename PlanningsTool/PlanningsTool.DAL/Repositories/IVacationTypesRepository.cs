using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IVacationTypesRepository : IGenericRepository<VacationType>
    {
        Task<IEnumerable<VacationType>> GetAllVacationTypesAsync();
        Task<VacationType> GetVacationTypeAsyncById(int id);
        Task<IEnumerable<VacationType>> GetVacationTypesByName(string name);
    }
}
