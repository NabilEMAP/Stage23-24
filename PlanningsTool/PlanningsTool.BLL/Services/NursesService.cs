using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.Nurses;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class NursesService : INursesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateNurseValidator _createValidator;
        private readonly UpdateNurseValidator _updateValidator;

        public NursesService(IUnitOfWork uow, IMapper mapper, CreateNurseValidator createValidator, UpdateNurseValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<NurseDTO> Add(CreateNurseDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if(!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var nurse = _mapper.Map<Nurse>(entity);
            await _uow.NursesRepository.Add(nurse);
            await _uow.Save();
            return _mapper.Map<NurseDTO>(nurse);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteNurse = await _uow.NursesRepository.GetNurseAsyncById(id);
            if (toDeleteNurse == null)
            {
                throw new KeyNotFoundException("Deze zorgkundige bestaat niet.");
            }
            _uow.NursesRepository.Delete(toDeleteNurse);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<NurseDTO>> GetAll()
        {
            var nurses = await _uow.NursesRepository.GetAllNursesAsync();
            return _mapper.Map<IEnumerable<NurseDTO>>(nurses);
        }

        public async Task<NurseDTO> GetById(int id)
        {
            var nurse = await _uow.NursesRepository.GetNurseAsyncById(id);
            return _mapper.Map<NurseDTO>(nurse);
        }

        public async Task<IEnumerable<NurseDTO>> GetNursesByLastName(string lastName)
        {
            var nurses = await _uow.NursesRepository.GetNursesByLastName(lastName);
            return _mapper.Map<IEnumerable<NurseDTO>>(nurses);
        }

        public async Task<IEnumerable<NurseDTO>> GetNursesByFirstName(string firstName)
        {
            var nurses = await _uow.NursesRepository.GetNursesByFirstName(firstName);
            return _mapper.Map<IEnumerable<NurseDTO>>(nurses);
        }

        public async Task<NurseDTO> Update(int id, UpdateNurseDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var nurseFromRequest = _mapper.Map<Nurse>(entity);
            var nurseToUpdate = await _uow.NursesRepository.GetNurseAsyncById(id);

            if (nurseToUpdate == null)
            {
                throw new KeyNotFoundException("Deze zorgkundige bestaat niet.");
            }

            nurseToUpdate.FirstName = nurseFromRequest.FirstName;
            nurseToUpdate.LastName = nurseFromRequest.LastName;
            nurseToUpdate.RegimeTypeId = nurseFromRequest.RegimeTypeId;
            nurseToUpdate.IsFixedNight = nurseFromRequest.IsFixedNight;

            await _uow.NursesRepository.Update(nurseToUpdate);
            await _uow.Save();
            return _mapper.Map<NurseDTO>(nurseToUpdate);
        }
    }
}
