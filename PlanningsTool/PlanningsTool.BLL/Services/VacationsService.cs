using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.Vacations;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class VacationsService : IVacationsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateVacationValidator _createValidator;
        private readonly UpdateVacationValidator _updateValidator;

        public VacationsService(IUnitOfWork uow, IMapper mapper, CreateVacationValidator createValidator, UpdateVacationValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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

        public async Task<VacationDetailDTO> Add(CreateVacationDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(entity.NurseId, entity.Startdate, entity.Enddate))
            {
                throw new Exception($"Het verlof bestaat al voor deze zorgkundige");
            }

            if (await CheckIfDatesOverlap(entity.NurseId, entity.Startdate, entity.Enddate))
            {
                throw new Exception($"Het verlof wordt overlapt met een bestaande verlof voor deze zorgkundige");
            }

            var vacation = _mapper.Map<Vacation>(entity);
            await _uow.VacationsRepository.Add(vacation);
            await _uow.Save();
            return _mapper.Map<VacationDetailDTO>(vacation);
        }

        public async Task<VacationDetailDTO> Update(int id, UpdateVacationDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(id, entity.NurseId, entity.Startdate, entity.Enddate))
            {
                throw new Exception($"Het verlof bestaat al voor deze zorgkundige");
            }

            if (await CheckIfDatesOverlap(entity.NurseId, entity.Startdate, entity.Enddate))
            {
                throw new Exception($"Het verlof wordt overlapt met een bestaande verlof voor deze zorgkundige");
            }

            var vacationFromRequest = _mapper.Map<Vacation>(entity);
            var vacationToUpdate = await _uow.VacationsRepository.GetVacationAsyncById(id);

            if (vacationToUpdate == null)
            {
                throw new KeyNotFoundException("Het verlof bestaat niet");
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

        public async Task<int> Delete(int id)
        {
            var toDeleteVerlof = await _uow.VacationsRepository.GetVacationAsyncById(id);
            if (toDeleteVerlof == null)
            {
                throw new KeyNotFoundException("Het verlof bestaat niet");
            }
            _uow.VacationsRepository.Delete(toDeleteVerlof);
            await _uow.Save();
            return 0;
        }

        public async Task<bool> CheckIfExist(int nurseId, DateTime startDate, DateTime endDate)
        {
            foreach (var item in await _uow.VacationsRepository.GetAllVacationsAsync())
            {
                if (
                    item.NurseId == nurseId &&
                    item.Startdate == startDate &&
                    item.Enddate == endDate
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfExist(int id, int nurseId, DateTime startDate, DateTime endDate)
        {
            foreach (var item in await _uow.VacationsRepository.GetAllVacationsAsync())
            {
                if (
                    item.Id != id &&
                    item.NurseId == nurseId &&
                    item.Startdate == startDate &&
                    item.Enddate == endDate
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfDatesOverlap(int nurseId, DateTime startDate, DateTime endDate)
        {
            foreach (var item in await _uow.VacationsRepository.GetAllVacationsAsync())
            {
                if (item.NurseId == nurseId && item.Startdate <= endDate && item.Enddate >= startDate)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
