using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class ShiftTypesService : IShiftTypesService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

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

        public async Task<IEnumerable<ShiftTypeDTO>> GetShiftTypesByNaam(string naam)
        {
            var shiftTypes = await _uow.ShiftTypesRepository.GetShiftTypesByNaam(naam);
            return _mapper.Map<IEnumerable<ShiftTypeDTO>>(shiftTypes);
        }
    }
}
