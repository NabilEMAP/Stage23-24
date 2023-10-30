using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Teamplanningen;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class TeamplanningenService : ITeamplanningenService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public TeamplanningenService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamplanningDTO>> GetAll()
        {
            var teamplanningen = await _uow.TeamplanningenRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamplanningDTO>>(teamplanningen);
        }

        public async Task<TeamplanningDTO> GetById(int id)
        {
            var teamplanning = await _uow.TeamplanningenRepository.GetByIdAsync(id);
            return _mapper.Map<TeamplanningDTO>(teamplanning);
        }

        public async Task<IEnumerable<TeamplanningDTO>> GetTeamplanningenByMaand(string maand)
        {
            var teamplanningen = await _uow.TeamplanningenRepository.GetTeamplanningenByMaand(maand);
            return _mapper.Map<IEnumerable<TeamplanningDTO>>(teamplanningen);
        }

        public async Task<TeamplanningDTO> Add(CreateTeamplanningDTO entity)
        {
            var teamplanning = _mapper.Map<Teamplanning>(entity);
            await _uow.TeamplanningenRepository.Add(teamplanning);
            await _uow.Save();
            return _mapper.Map<TeamplanningDTO>(teamplanning);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteTeamplanning = await _uow.TeamplanningenRepository.GetByIdAsync(id);
            if (toDeleteTeamplanning == null)
            {
                throw new KeyNotFoundException("This teamplanning does not exist.");
            }
            _uow.TeamplanningenRepository.Delete(toDeleteTeamplanning);
            await _uow.Save();
            return 0;
        }

        public async Task<TeamplanningDTO> Update(int id, UpdateTeamplanningDTO entity)
        {
            var teamplanningFromRequest = _mapper.Map<Teamplanning>(entity);
            var teamplanningToUpdate = await _uow.TeamplanningenRepository.GetByIdAsync(id);

            if (teamplanningToUpdate == null)
            {
                throw new KeyNotFoundException("This teamplanning does not exist.");
            }

            teamplanningToUpdate.Maand = teamplanningFromRequest.Maand;

            await _uow.TeamplanningenRepository.Update(teamplanningToUpdate);
            await _uow.Save();
            return _mapper.Map<TeamplanningDTO>(teamplanningToUpdate);
        }
    }
}
