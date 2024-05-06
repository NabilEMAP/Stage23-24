using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class ShiftsService : IShiftsService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShiftsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShiftDTO>> GetAll()
        {
            var shifts = await _uow.ShiftsRepository.GetAllShiftsAsync();
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<ShiftDTO> GetById(int id)
        {
            var shift = await _uow.ShiftsRepository.GetShiftAsyncById(id);
            return _mapper.Map<ShiftDTO>(shift);
        }

        public async Task<IEnumerable<ShiftDTO>> GetShiftsByStarttime(string starttime)
        {
            var shifts = await _uow.ShiftsRepository.GetShiftsByStarttime(starttime);
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<IEnumerable<ShiftDTO>> GetShiftsByEndtime(string endtime)
        {
            var shifts = await _uow.ShiftsRepository.GetShiftsByEndtime(endtime);
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }
    }
}
