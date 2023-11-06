using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface ITeamplansRepository : IGenericRepository<Teamplan>
    {
        Task<IEnumerable<Teamplan>> GetTeamplansByMonth(string month);
    }
}
