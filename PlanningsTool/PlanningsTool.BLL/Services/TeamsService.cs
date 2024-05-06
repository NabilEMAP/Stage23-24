using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.Teams;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateTeamValidator _createValidator;
        private readonly UpdateTeamValidator _updateValidator;

        public TeamsService(IUnitOfWork uow, IMapper mapper, CreateTeamValidator createValidator, UpdateTeamValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }        

        public async Task<IEnumerable<TeamDTO>> GetAll()
        {
            var teams = await _uow.TeamsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetById(int id)
        {
            var team = await _uow.TeamsRepository.GetTeamAsyncById(id);
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<IEnumerable<TeamDTO>> GetTeamsByTeamName(string teamName)
        {
            var teams = await _uow.TeamsRepository.GetTeamsByTeamName(teamName);
            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> Add(CreateTeamDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(entity.TeamName))
            {
                throw new Exception($"Deze team bestaat al.");
            }

            var team = _mapper.Map<Team>(entity);
            await _uow.TeamsRepository.Add(team);
            await _uow.Save();
            return _mapper.Map<TeamDTO>(team);
        }

        public async Task<TeamDTO> Update(int id, UpdateTeamDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(id, entity.TeamName))
            {
                throw new Exception($"Deze team bestaat al.");
            }

            var teamFromRequest = _mapper.Map<Team>(entity);
            var teamToUpdate = await _uow.TeamsRepository.GetTeamAsyncById(id);

            if (teamToUpdate == null)
            {
                throw new KeyNotFoundException("Deze team bestaat niet.");
            }

            teamToUpdate.TeamName = teamFromRequest.TeamName;

            await _uow.TeamsRepository.Update(teamToUpdate);
            await _uow.Save();
            return _mapper.Map<TeamDTO>(teamToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteTeam = await _uow.TeamsRepository.GetTeamAsyncById(id);
            if (toDeleteTeam == null)
            {
                throw new KeyNotFoundException("Deze team bestaat niet.");
            }
            _uow.TeamsRepository.Delete(toDeleteTeam);
            await _uow.Save();
            return 0;
        }

        public async Task<bool> CheckIfExist(string teamName)
        {
            foreach (var item in await _uow.TeamsRepository.GetAllTeamsAsync())
            {
                if (
                    item.TeamName == teamName
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfExist(int id, string teamName)
        {
            foreach (var item in await _uow.TeamsRepository.GetAllTeamsAsync())
            {
                if (
                    item.Id != id &&
                    item.TeamName == teamName
                )
                {
                    return true;
                }
            }
            return false;
        }
    }
}