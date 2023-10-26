using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.Common.DTO.Teamplanningen;
using PlanningsTool.Common.DTO.ZorgkundigeShifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface ITeamplanningenService
    {
        public Task<IEnumerable<TeamplanningDTO>> GetAll();
        public Task<TeamplanningDTO> GetById(int id);
        public Task<IEnumerable<TeamplanningDTO>> GetTeamplanningenByMaand(string maand);
        public Task<TeamplanningDTO> Add(CreateTeamplanningDTO teamplanning);
        public Task<TeamplanningDTO> Update(int id, UpdateTeamplanningDTO teamplanning);
        public Task<int> Delete(int id);
    }
}
