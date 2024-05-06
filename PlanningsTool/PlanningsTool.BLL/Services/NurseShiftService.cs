using AutoMapper;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.NurseShifts;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class NurseShiftService : INurseShiftsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateNurseShiftValidator _createValidator;
        private readonly UpdateNurseShiftValidator _updateValidator;

        public NurseShiftService(IUnitOfWork uow, IMapper mapper, CreateNurseShiftValidator createValidator, UpdateNurseShiftValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<NurseShiftDTO>> GetAll()
        {
            var nurses = await _uow.NurseShiftsRepository.GetAllNurseShiftsAsync();
            return _mapper.Map<IEnumerable<NurseShiftDTO>>(nurses);
        }

        public async Task<NurseShiftDTO> GetById(int id)
        {
            var nurse = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);
            return _mapper.Map<NurseShiftDTO>(nurse);
        }

        public async Task<IEnumerable<NurseShiftDTO>> GetNurseShiftsByDate(string date)
        {
            var nurses = await _uow.NurseShiftsRepository.GetNurseShiftsByDate(date);
            return _mapper.Map<IEnumerable<NurseShiftDTO>>(nurses);
        }

        public async Task<NurseShiftDTO> Add(CreateNurseShiftDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(entity.NurseId, entity.ShiftId, entity.Date))
            {
                throw new Exception($"De zorgkundige shift bestaat al");
            }

            var nurse = _mapper.Map<NurseShift>(entity);
            await _uow.NurseShiftsRepository.Add(nurse);
            await _uow.Save();
            return _mapper.Map<NurseShiftDTO>(nurse);
        }

        public async Task<NurseShiftDTO> Update(int id, UpdateNurseShiftDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(id, entity.NurseId, entity.ShiftId, entity.Date))
            {
                throw new Exception($"De zorgkundige shift bestaat al");
            }

            var nurseFromRequest = _mapper.Map<NurseShift>(entity);
            var nurseToUpdate = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);

            if (nurseToUpdate == null)
            {
                throw new KeyNotFoundException("Deze zorgkundige shift bestaat niet");
            }

            nurseToUpdate.Date = nurseFromRequest.Date;
            nurseToUpdate.NurseId = nurseFromRequest.NurseId;
            nurseToUpdate.ShiftId = nurseFromRequest.ShiftId;
            nurseToUpdate.TeamplanId = nurseFromRequest.TeamplanId;

            await _uow.NurseShiftsRepository.Update(nurseToUpdate);
            await _uow.Save();
            return _mapper.Map<NurseShiftDTO>(nurseToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteZorgkundige = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);
            if (toDeleteZorgkundige == null)
            {
                throw new KeyNotFoundException("Deze zorgkundige shift bestaat niet");
            }
            _uow.NurseShiftsRepository.Delete(toDeleteZorgkundige);
            await _uow.Save();
            return 0;
        }

        public async Task<bool> CheckIfExist(int nurseId, int shiftId, DateTime date)
        {
            foreach (var item in await _uow.NurseShiftsRepository.GetAllNurseShiftsAsync())
            {
                if (
                    item.NurseId == nurseId &&
                    item.ShiftId == shiftId &&
                    item.Date == date
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfExist(int id, int nurseId, int shiftId, DateTime date)
        {
            foreach (var item in await _uow.NurseShiftsRepository.GetAllNurseShiftsAsync())
            {
                if (
                    item.Id != id &&
                    item.NurseId == nurseId &&
                    item.ShiftId == shiftId &&
                    item.Date == date
                )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
