using AutoMapper;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class HolidaysService : IHolidaysService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateHolidayValidator _createValidator;
        private readonly UpdateHolidayValidator _updateValidator;

        public HolidaysService(IUnitOfWork uow, IMapper mapper, CreateHolidayValidator createValidator, UpdateHolidayValidator updateValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IEnumerable<HolidayDTO>> GetAll()
        {
            var holidays = await _uow.HolidaysRepository.GetAllHolidaysAsync();
            return _mapper.Map<IEnumerable<HolidayDTO>>(holidays);
        }

        public async Task<HolidayDTO> GetById(int id)
        {
            var holiday = await _uow.HolidaysRepository.GetHolidayAsyncById(id);
            return _mapper.Map<HolidayDTO>(holiday);
        }

        public async Task<IEnumerable<HolidayDTO>> GetHolidaysByDate(string date)
        {
            var holidays = await _uow.HolidaysRepository.GetHolidaysByDate(date);
            return _mapper.Map<IEnumerable<HolidayDTO>>(holidays);
        }

        public async Task<IEnumerable<HolidayDTO>> GetHolidaysByName(string name)
        {
            var holidays = await _uow.HolidaysRepository.GetHolidaysByName(name);
            return _mapper.Map<IEnumerable<HolidayDTO>>(holidays);
        }

        public async Task<int> Generate(int year)
        {
            if (await CheckIfYearExist(year))
            {
                throw new Exception($"Het year {year} bestaat al in de lijst");
            }
            await _uow.HolidaysRepository.AddHolidaysByYear(year);
            await _uow.Save();
            return _mapper.Map<int>(year);
        }

        public async Task<int> ClearAll()
        {
            foreach (var item in await _uow.HolidaysRepository.GetAllAsync())
            {
                _uow.HolidaysRepository.Delete(item);
            }
            await _uow.Save();
            return 0;
        }

        public async Task<HolidayDTO> Add(CreateHolidayDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(entity.Name, entity.Date))
            {
                throw new Exception($"Feestdag bestaat al");
            }

            var holiday = _mapper.Map<Holiday>(entity);
            await _uow.HolidaysRepository.Add(holiday);
            await _uow.Save();
            return _mapper.Map<HolidayDTO>(holiday);
        }

        public async Task<HolidayDTO> Update(int id, UpdateHolidayDTO entity)
        {
            ValidationResult validationResult = _updateValidator.Validate(entity);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            if (await CheckIfExist(id, entity.Name, entity.Date))
            {
                throw new Exception($"Feestdag bestaat al");
            }

            var holidayFromRequest = _mapper.Map<Holiday>(entity);
            var holidayToUpdate = await _uow.HolidaysRepository.GetHolidayAsyncById(id);

            if (holidayToUpdate == null)
            {
                throw new KeyNotFoundException("Feestdag bestaat niet");
            }

            holidayToUpdate.Name = holidayFromRequest.Name;
            holidayToUpdate.Date = holidayFromRequest.Date;

            await _uow.HolidaysRepository.Update(holidayToUpdate);
            await _uow.Save();
            return _mapper.Map<HolidayDTO>(holidayToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteFeestdag = await _uow.HolidaysRepository.GetHolidayAsyncById(id);
            if (toDeleteFeestdag == null)
            {
                throw new KeyNotFoundException("Feestdag bestaat niet");
            }
            _uow.HolidaysRepository.Delete(toDeleteFeestdag);
            await _uow.Save();
            return 0;
        }

        public async Task<bool> CheckIfYearExist(int year)
        {
            var holidays = await _uow.HolidaysRepository.GetHolidayByYear(year);
            return holidays.Any();
        }

        public async Task<bool> CheckIfExist(string name, DateTime date)
        {
            foreach (var item in await _uow.HolidaysRepository.GetAllHolidaysAsync())
            {
                if (
                    item.Name == name &&
                    item.Date == date
                )
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> CheckIfExist(int id, string name, DateTime date)
        {
            foreach (var item in await _uow.HolidaysRepository.GetAllHolidaysAsync())
            {
                if (
                    item.Id != id &&
                    item.Name == name &&
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
