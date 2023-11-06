
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface INursesRepository : IGenericRepository<Nurse>
    {
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task<Nurse> GetNurseAsyncById(int id);
        Task<IEnumerable<Nurse>> GetNursesByLastName(string lastName);
        Task<IEnumerable<Nurse>> GetNursesByFirstName(string firstName);

    }
}
