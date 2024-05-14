using PlanningsTool.Common.DTO.Teamplans;

namespace PlanningsTool.BLL.Interfaces
{
    public interface ITeamplansService
    {
        public Task<IEnumerable<TeamplanDTO>> GetAll();
        public Task<TeamplanDTO> GetById(int id);
        public Task<IEnumerable<TeamplanDTO>> GetTeamplansByName(string name);
        public Task<IEnumerable<TeamplanDTO>> GetTeamplansByPlanFor(string planFor);
        public Task<IEnumerable<TeamplanDTO>> GetTeamplansByCreatedOn(string createdOn);
        public Task<TeamplanDTO> Add(CreateTeamplanDTO teamplan);
        public Task<TeamplanDTO> Update(int id, UpdateTeamplanDTO teamplan);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfExist(string name);
        public Task<bool> CheckIfExist(int id, string name);
    }
}
