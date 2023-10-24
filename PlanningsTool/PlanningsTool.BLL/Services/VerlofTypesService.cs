using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.VerlofTypes;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class VerlofTypesService : IVerlofTypesService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public VerlofTypesService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VerlofTypeDTO>> GetAll()
        {
            var verlofTypes = await _uow.VerlofTypesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VerlofTypeDTO>>(verlofTypes);
        }

        public async Task<VerlofTypeDTO> GetById(int id)
        {
            var verlofType = await _uow.VerlofTypesRepository.GetByIdAsync(id);
            return _mapper.Map<VerlofTypeDTO>(verlofType);
        }

        public async Task<IEnumerable<VerlofTypeDTO>> GetVerlofTypesByNaam(string naam)
        {
            var verlofTypes = await _uow.VerlofTypesRepository.GetVerlofTypesByNaam(naam);
            return _mapper.Map<IEnumerable<VerlofTypeDTO>>(verlofTypes);
        }
    }
}
