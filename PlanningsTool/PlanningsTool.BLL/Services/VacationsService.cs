using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Vacations;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class VacationsService : IVacationsService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public VacationsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<VacationDetailDTO> Add(CreateVacationDTO entity)
        {
            var vacation = _mapper.Map<Vacation>(entity);
            await _uow.VacationsRepository.Add(vacation);
            await _uow.Save();
            return _mapper.Map<VacationDetailDTO>(vacation);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteVerlof = await _uow.VacationsRepository.GetVacationAsyncById(id);
            if (toDeleteVerlof == null)
            {
                throw new KeyNotFoundException("This vacation does not exist.");
            }
            _uow.VacationsRepository.Delete(toDeleteVerlof);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<VacationDTO>> GetAll()
        {
            var vacations = await _uow.VacationsRepository.GetAllVacationsAsync();
            return _mapper.Map<IEnumerable<VacationDTO>>(vacations);
        }

        public async Task<IEnumerable<VacationDetailDTO>> GetAllDetails()
        {
            var vacations = await _uow.VacationsRepository.GetAllVacationsAsync();
            return _mapper.Map<IEnumerable<VacationDetailDTO>>(vacations);
        }

        public async Task<VacationDetailDTO> GetById(int id)
        {
            var vacation = await _uow.VacationsRepository.GetVacationAsyncById(id);
            return _mapper.Map<VacationDetailDTO>(vacation);
        }

        public async Task<IEnumerable<VacationDetailDTO>> GetVacationsByStartdate(string startdate)
        {
            var vacations = await _uow.VacationsRepository.GetVacationsByStartdate(startdate);
            return _mapper.Map<IEnumerable<VacationDetailDTO>>(vacations);
        }

        public async Task<IEnumerable<VacationDetailDTO>> GetVacationsByEnddate(string enddate)
        {
            var vacations = await _uow.VacationsRepository.GetVacationsByEnddate(enddate);
            return _mapper.Map<IEnumerable<VacationDetailDTO>>(vacations);
        }

        public async Task<IEnumerable<VacationDetailDTO>> GetVacationsByReason(string reason)
        {
            var vacations = await _uow.VacationsRepository.GetVacationsByReason(reason);
            return _mapper.Map<IEnumerable<VacationDetailDTO>>(vacations);
        }

        public async Task<VacationDetailDTO> Update(int id, UpdateVacationDTO entity)
        {
            var vacationFromRequest = _mapper.Map<Vacation>(entity);
            var vacationToUpdate = await _uow.VacationsRepository.GetVacationAsyncById(id);

            if (vacationToUpdate == null)
            {
                throw new KeyNotFoundException("Dit vacation bestaat niet.");
            }

            vacationToUpdate.Startdate = vacationFromRequest.Startdate;
            vacationToUpdate.Enddate = vacationFromRequest.Enddate;
            vacationToUpdate.Reason = vacationFromRequest.Reason;
            vacationToUpdate.NurseId = vacationFromRequest.NurseId;
            vacationToUpdate.VacationTypeId = vacationFromRequest.VacationTypeId;

            await _uow.VacationsRepository.Update(vacationToUpdate);
            await _uow.Save();
            return _mapper.Map<VacationDetailDTO>(vacationToUpdate);
        }
    }
}
