using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IRegimeTypesRepository : IGenericRepository<RegimeType>
    {
        Task<IEnumerable<RegimeType>> GetAllRegimeTypesAsync();
        Task<RegimeType> GetRegimeTypeAsyncById(int id);
        Task<IEnumerable<RegimeType>> GetRegimeTypesByName(string name);
        Task<IEnumerable<RegimeType>> GetRegimeTypesByCountHours(string countHours);

    }
}
