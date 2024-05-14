using AutoMapper;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.Teamplans;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class TeamplansService : ITeamplansService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateTeamplanValidator _createValidator;
        private readonly UpdateTeamplanValidator _updateValidator;


        public TeamplansService(IUnitOfWork uow, IMapper mapper, CreateTeamplanValidator createValidator, UpdateTeamplanValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<TeamplanDTO>> GetAll()
        {
            var teamplans = await _uow.TeamplansRepository.GetAllTeamplansAsync();
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplans);
        }

        public async Task<TeamplanDTO> GetById(int id)
        {
            var teamplan = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);
            return _mapper.Map<TeamplanDTO>(teamplan);
        }

        public async Task<IEnumerable<TeamplanDTO>> GetTeamplansByName(string name)
        {
            var teamplans = await _uow.TeamplansRepository.GetTeamplansByName(name);
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplans);
        }

        public async Task<IEnumerable<TeamplanDTO>> GetTeamplansByPlanFor(string planFor)
        {
            var teamplans = await _uow.TeamplansRepository.GetTeamplansByName(planFor);
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplans);
        }

        public async Task<IEnumerable<TeamplanDTO>> GetTeamplansByCreatedOn(string createdOn)
        {
            var teamplans = await _uow.TeamplansRepository.GetTeamplansByName(createdOn);
            return _mapper.Map<IEnumerable<TeamplanDTO>>(teamplans);
        }

        public async Task<TeamplanDTO> Add(CreateTeamplanDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(entity.Name))
            {
                throw new Exception($"De teamplan bestaat al");
            }

            var teamplan = _mapper.Map<Teamplan>(entity);
            await _uow.TeamplansRepository.Add(teamplan);
            await _uow.Save();
            return _mapper.Map<TeamplanDTO>(teamplan);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteTeamplan = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);
            if (toDeleteTeamplan == null)
            {
                throw new KeyNotFoundException("Deze teamplan bestaat niet.");
            }
            _uow.TeamplansRepository.Delete(toDeleteTeamplan);
            await _uow.Save();
            return 0;
        }

        public async Task<TeamplanDTO> Update(int id, UpdateTeamplanDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(id, entity.Name))
            {
                throw new Exception($"De teamplan bestaat al");
            }
            var teamplanFromRequest = _mapper.Map<Teamplan>(entity);
            var teamplanToUpdate = await _uow.TeamplansRepository.GetTeamplanAsyncById(id);

            if (teamplanToUpdate == null)
            {
                throw new KeyNotFoundException("Deze teamplan bestaat niet.");
            }

            teamplanToUpdate.Name = teamplanFromRequest.Name;
            teamplanToUpdate.PlanFor = teamplanFromRequest.PlanFor;
            teamplanToUpdate.CreatedOn = teamplanFromRequest.CreatedOn;

            await _uow.TeamplansRepository.Update(teamplanToUpdate);
            await _uow.Save();
            return _mapper.Map<TeamplanDTO>(teamplanToUpdate);
        }

        public async Task<bool> CheckIfExist(string name)
        {
            foreach (var item in await _uow.TeamplansRepository.GetAllTeamplansAsync())
            {
                if (
                    item.Name == name
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfExist(int id, string name)
        {
            foreach (var item in await _uow.TeamplansRepository.GetAllTeamplansAsync())
            {
                if (
                    item.Id != id &&
                    item.Name == name
                )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
