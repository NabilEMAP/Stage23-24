using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface ITeamplansRepository : IGenericRepository<Teamplan>
    {
        Task<IEnumerable<Teamplan>> GetAllTeamplansAsync();
        Task<Teamplan> GetTeamplanAsyncById(int id);
        Task<IEnumerable<Teamplan>> GetTeamplansByName(string name);
        Task<IEnumerable<Teamplan>> GetTeamplansByPlanFor(string planFor);
        Task<IEnumerable<Teamplan>> GetTeamplansByCreatedOn(string createdOn);
    }
}