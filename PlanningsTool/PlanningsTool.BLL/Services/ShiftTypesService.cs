using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class ShiftTypesService : IShiftTypesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ShiftTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShiftTypeDTO>> GetAll()
        {
            var shiftTypes = await _uow.ShiftTypesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShiftTypeDTO>>(shiftTypes);
        }

        public async Task<ShiftTypeDTO> GetById(int id)
        {
            var shiftType = await _uow.ShiftTypesRepository.GetByIdAsync(id);
            return _mapper.Map<ShiftTypeDTO>(shiftType);
        }

        public async Task<IEnumerable<ShiftTypeDTO>> GetShiftTypesByName(string name)
        {
            var shiftTypes = await _uow.ShiftTypesRepository.GetShiftTypesByName(name);
            return _mapper.Map<IEnumerable<ShiftTypeDTO>>(shiftTypes);
        }
    }
}
