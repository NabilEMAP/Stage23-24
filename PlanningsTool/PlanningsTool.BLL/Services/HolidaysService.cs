using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class HolidaysService : IHolidaysService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public HolidaysService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Generate(int year)
        {
            if (await CheckIfExist(year))
            {
                throw new Exception($"Het year {year} bestaat al in de lijst");
            }
            await _uow.HolidaysRepository.AddHolidaysByYear(year);
            await _uow.Save();
            return _mapper.Map<int>(year);
        }

        public async Task<bool> CheckIfExist(int year)
        {
            var holidays = await _uow.HolidaysRepository.GetHolidayByYear(year);
            return holidays.Any();
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

        public async Task<IEnumerable<HolidayDTO>> GetAll()
        {
            var holidays = await _uow.HolidaysRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HolidayDTO>>(holidays);
        }

        public async Task<HolidayDTO> GetById(int id)
        {
            var holiday = await _uow.HolidaysRepository.GetByIdAsync(id);
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
    }
}
