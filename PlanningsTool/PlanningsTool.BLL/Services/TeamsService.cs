using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Teams;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class TeamsService : ITeamsService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public TeamsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDTO>> GetAll()
        {
            var teams = await _uow.TeamsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetById(int id)
        {
            var team = await _uow.TeamsRepository.GetByIdAsync(id);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<IEnumerable<TeamDTO>> GetTeamsByTeamName(string teamName)
        {
            var teams = await _uow.TeamsRepository.GetTeamsByTeamName(teamName);
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> Add(CreateTeamDTO entity)
        {
            var team = _mapper.Map<Team>(entity);
            await _uow.TeamsRepository.Add(team);
            await _uow.Save();
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteTeam = await _uow.TeamsRepository.GetByIdAsync(id);
            if (toDeleteTeam == null)
            {
                throw new KeyNotFoundException("Deze team bestaat niet.");
            }
            _uow.TeamsRepository.Delete(toDeleteTeam);
            await _uow.Save();
            return 0;
        }

        public async Task<TeamDTO> Update(int id, UpdateTeamDTO entity)
        {
            var teamFromRequest = _mapper.Map<Team>(entity);
            var teamToUpdate = await _uow.TeamsRepository.GetByIdAsync(id);

            if (teamToUpdate == null)
            {
                throw new KeyNotFoundException("Deze team bestaat niet.");
            }

            teamToUpdate.TeamName = teamFromRequest.TeamName;

            await _uow.TeamsRepository.Update(teamToUpdate);
            await _uow.Save();
            return _mapper.Map<TeamDTO>(teamToUpdate);
        }
    }
}