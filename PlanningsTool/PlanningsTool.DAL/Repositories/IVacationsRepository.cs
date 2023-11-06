using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IVacationsRepository : IGenericRepository<Vacation>
    {
        Task<IEnumerable<Vacation>> GetAllVacationsAsync();
        Task<Vacation> GetVacationAsyncById(int id);
        Task<IEnumerable<Vacation>> GetVacationsByStartdate(string startdate);
        Task<IEnumerable<Vacation>> GetVacationsByEnddate(string enddate);
        Task<IEnumerable<Vacation>> GetVacationsByReason(string reason);
    }
}
