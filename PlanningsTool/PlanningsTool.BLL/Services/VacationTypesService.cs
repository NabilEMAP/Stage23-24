using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.VacationTypes;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class VacationTypesService : IVacationTypesService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public VacationTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacationTypeDTO>> GetAll()
        {
            var verlofTypes = await _uow.VacationTypesRepository.GetAllVacationTypesAsync();
            return _mapper.Map<IEnumerable<VacationTypeDTO>>(verlofTypes);
        }

        public async Task<VacationTypeDTO> GetById(int id)
        {
            var verlofType = await _uow.VacationTypesRepository.GetVacationTypeAsyncById(id);
            return _mapper.Map<VacationTypeDTO>(verlofType);
        }

        public async Task<IEnumerable<VacationTypeDTO>> GetVacationTypesByName(string name)
        {
            var verlofTypes = await _uow.VacationTypesRepository.GetVacationTypesByName(name);
            return _mapper.Map<IEnumerable<VacationTypeDTO>>(verlofTypes);
        }
    }
}
