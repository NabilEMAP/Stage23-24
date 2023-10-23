using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class RegimeTypesService : IRegimeTypesService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

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

        public async Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByNaam(string naam)
        {
            var regimeTypes = await _uow.RegimeTypesRepository.GetRegimeTypesByNaam(naam);
            return _mapper.Map<IEnumerable<RegimeTypeDTO>>(regimeTypes);
        }

        public async Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByAantalUren(string aantalUren)
        {
            var regimeTypes = await _uow.RegimeTypesRepository.GetRegimeTypesByAantalUren(aantalUren);
            return _mapper.Map<IEnumerable<RegimeTypeDTO>>(regimeTypes);
        }
    }
}
