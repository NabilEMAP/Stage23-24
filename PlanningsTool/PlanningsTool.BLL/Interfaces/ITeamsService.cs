using PlanningsTool.Common.DTO.Teams;
namespace PlanningsTool.BLL.Interfaces
{
    public interface ITeamsService
    {
        public Task<IEnumerable<TeamDTO>> GetAll();
        public Task<TeamDTO> GetById(int id);
        public Task<IEnumerable<TeamDTO>> GetTeamsByTeamName(string teamName);
        public Task<TeamDTO> Add(CreateTeamDTO teamplan);
        public Task<TeamDTO> Update(int id, UpdateTeamDTO teamplan);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfExist(string teamName);
        public Task<bool> CheckIfExist(int id, string teamName);
    }
}
