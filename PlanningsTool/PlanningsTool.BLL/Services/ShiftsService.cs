using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class ShiftsService : IShiftsService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public ShiftsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ShiftDTO> Add(CreateShiftDTO entity)
        {
            var shift = _mapper.Map<Shift>(entity);
            await _uow.ShiftsRepository.Add(shift);
            await _uow.Save();
            return _mapper.Map<ShiftDTO>(shift);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteShift = await _uow.ShiftsRepository.GetShiftAsyncById(id);
            if (toDeleteShift == null)
            {
                throw new KeyNotFoundException("This shift does not exist.");
            }
            _uow.ShiftsRepository.Delete(toDeleteShift);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<ShiftDTO>> GetAll()
        {
            var shifts = await _uow.ShiftsRepository.GetAllShiftsAsync();
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<IEnumerable<ShiftDTO>> GetAllDetails()
        {
            var shifts = await _uow.ShiftsRepository.GetAllShiftsAsync();
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<ShiftDTO> GetById(int id)
        {
            var shift = await _uow.ShiftsRepository.GetShiftAsyncById(id);
            return _mapper.Map<ShiftDTO>(shift);
        }

        public async Task<IEnumerable<ShiftDTO>> GetShiftsByStarttijd(string starttijd)
        {
            var shifts = await _uow.ShiftsRepository.GetShiftsByStarttijd(starttijd);
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<IEnumerable<ShiftDTO>> GetShiftsByEindtijd(string eindtijd)
        {
            var shifts = await _uow.ShiftsRepository.GetShiftsByEindtijd(eindtijd);
            return _mapper.Map<IEnumerable<ShiftDTO>>(shifts);
        }

        public async Task<ShiftDTO> Update(int id, UpdateShiftDTO entity)
        {
            var shiftFromRequest = _mapper.Map<Shift>(entity);
            var shiftToUpdate = await _uow.ShiftsRepository.GetShiftAsyncById(id);

            if (shiftToUpdate == null)
            {
                throw new KeyNotFoundException("This shift does not exist.");
            }

            shiftToUpdate.Starttijd = shiftFromRequest.Starttijd;
            shiftToUpdate.Eindtijd = shiftFromRequest.Eindtijd;
            shiftToUpdate.ShiftTypeId = shiftFromRequest.ShiftTypeId;

            await _uow.ShiftsRepository.Update(shiftToUpdate);
            await _uow.Save();
            return _mapper.Map<ShiftDTO>(shiftToUpdate);
        }
    }
}
