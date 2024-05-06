using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Teamplans;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class TeamplansService : ITeamplansService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TeamplansService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamplanDTO>> GetAll()
        {
            var teamplanningen = await _uow.TeamplansRepository.GetAllTeamplansAsync();
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplanningen);
        }

        public async Task<TeamplanDTO> GetById(int id)
        {
            var teamplanning = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);
            return _mapper.Map<TeamplanDTO>(teamplanning);
        }

        public async Task<IEnumerable<TeamplanDTO>> GetTeamplansByMonth(string month)
        {
            var teamplanningen = await _uow.TeamplansRepository.GetTeamplansByMonth(month);
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplanningen);
        }

        public async Task<TeamplanDTO> Add(CreateTeamplanDTO entity)
        {
            var teamplanning = _mapper.Map<Teamplan>(entity);
            await _uow.TeamplansRepository.Add(teamplanning);
            await _uow.Save();
            return _mapper.Map<TeamplanDTO>(teamplanning);
        }
        
        public async Task<TeamplanDTO> Update(int id, UpdateTeamplanDTO entity)
        {
            var teamplanningFromRequest = _mapper.Map<Teamplan>(entity);
            var teamplanningToUpdate = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);

            if (teamplanningToUpdate == null)
            {
                throw new KeyNotFoundException("Deze teamplanning bestaat niet.");
            }

            teamplanningToUpdate.Month = teamplanningFromRequest.Month;

            await _uow.TeamplansRepository.Update(teamplanningToUpdate);
            await _uow.Save();
            return _mapper.Map<TeamplanDTO>(teamplanningToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteTeamplanning = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);
            if (toDeleteTeamplanning == null)
            {
                throw new KeyNotFoundException("Deze teamplanning bestaat niet.");
            }
            _uow.TeamplansRepository.Delete(toDeleteTeamplanning);
            await _uow.Save();
            return 0;
        }
    }
}
