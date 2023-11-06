using PlanningsTool.Common.DTO.Teamplans;

namespace PlanningsTool.BLL.Interfaces
{
    public interface ITeamplansService
    {
        public Task<IEnumerable<TeamplanDTO>> GetAll();
        public Task<TeamplanDTO> GetById(int id);
        public Task<IEnumerable<TeamplanDTO>> GetTeamplansByMonth(string month);
        public Task<TeamplanDTO> Add(CreateTeamplanDTO teamplan);
        public Task<TeamplanDTO> Update(int id, UpdateTeamplanDTO teamplan);
        public Task<int> Delete(int id);
    }
}
