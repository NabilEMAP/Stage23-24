using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.VacationTypes;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class VacationTypesService : IVacationTypesService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public VacationTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacationTypeDTO>> GetAll()
        {
            var verlofTypes = await _uow.VacationTypesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VacationTypeDTO>>(verlofTypes);
        }

        public async Task<VacationTypeDTO> GetById(int id)
        {
            var verlofType = await _uow.VacationTypesRepository.GetByIdAsync(id);
            return _mapper.Map<VacationTypeDTO>(verlofType);
        }

        public async Task<IEnumerable<VacationTypeDTO>> GetVacationTypesByName(string name)
        {
            var verlofTypes = await _uow.VacationTypesRepository.GetVacationTypesByName(name);
            return _mapper.Map<IEnumerable<VacationTypeDTO>>(verlofTypes);
        }
    }
}
