using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class RegimeTypesService : IRegimeTypesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RegimeTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegimeTypeDTO>> GetAll()
        {
            var regimeTypes = await _uow.RegimeTypesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RegimeTypeDTO>>(regimeTypes);
        }

        public async Task<RegimeTypeDTO> GetById(int id)
        {
            var regimeType = await _uow.RegimeTypesRepository.GetByIdAsync(id);
            return _mapper.Map<RegimeTypeDTO>(regimeType);
        }

        public async Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByName(string name)
        {
            var regimeTypes = await _uow.RegimeTypesRepository.GetRegimeTypesByName(name);
            return _mapper.Map<IEnumerable<RegimeTypeDTO>>(regimeTypes);
        }

        public async Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByCountHours(string countHours)
        {
            var regimeTypes = await _uow.RegimeTypesRepository.GetRegimeTypesByCountHours(countHours);
            return _mapper.Map<IEnumerable<RegimeTypeDTO>>(regimeTypes);
        }
    }
}
