using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.ZorgkundigeShifts;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class ZorgkundigeShiftService : IZorgkundigeShiftsService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public ZorgkundigeShiftService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ZorgkundigeShiftDTO> Add(CreateZorgkundigeShiftDTO entity)
        {
            var zorgkundige = _mapper.Map<ZorgkundigeShift>(entity);
            await _uow.ZorgkundigeShiftsRepository.Add(zorgkundige);
            await _uow.Save();
            return _mapper.Map<ZorgkundigeShiftDTO>(zorgkundige);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteZorgkundige = await _uow.ZorgkundigeShiftsRepository.GetZorgkundigeShiftAsyncById(id);
            if (toDeleteZorgkundige == null)
            {
                throw new KeyNotFoundException("This zorgkundige shift does not exist.");
            }
            _uow.ZorgkundigeShiftsRepository.Delete(toDeleteZorgkundige);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<ZorgkundigeShiftDTO>> GetAll()
        {
            var zorgkundigen = await _uow.ZorgkundigeShiftsRepository.GetAllZorgkundigeShiftsAsync();
            return _mapper.Map<IEnumerable<ZorgkundigeShiftDTO>>(zorgkundigen);
        }

        public async Task<ZorgkundigeShiftDTO> GetById(int id)
        {
            var zorgkundige = await _uow.ZorgkundigeShiftsRepository.GetZorgkundigeShiftAsyncById(id);
            return _mapper.Map<ZorgkundigeShiftDTO>(zorgkundige);
        }

        public async Task<IEnumerable<ZorgkundigeShiftDTO>> GetZorgkundigeShiftsByDatum(string datum)
        {
            var zorgkundigen = await _uow.ZorgkundigeShiftsRepository.GetZorgkundigeShiftsByDatum(datum);
            return _mapper.Map<IEnumerable<ZorgkundigeShiftDTO>>(zorgkundigen);
        }

        public async Task<ZorgkundigeShiftDTO> Update(int id, UpdateZorgkundigeShiftDTO entity)
        {
            var zorgkundigeFromRequest = _mapper.Map<ZorgkundigeShift>(entity);
            var zorgkundigeToUpdate = await _uow.ZorgkundigeShiftsRepository.GetZorgkundigeShiftAsyncById(id);

            if (zorgkundigeToUpdate == null)
            {
                throw new KeyNotFoundException("This zorgkundige shift does not exist.");
            }

            zorgkundigeToUpdate.Datum = zorgkundigeFromRequest.Datum;
            zorgkundigeToUpdate.ZorgkundigeId = zorgkundigeFromRequest.ZorgkundigeId;
            zorgkundigeToUpdate.ShiftId = zorgkundigeFromRequest.ShiftId;
            zorgkundigeToUpdate.TeamplanningId = zorgkundigeFromRequest.TeamplanningId;

            await _uow.ZorgkundigeShiftsRepository.Update(zorgkundigeToUpdate);
            await _uow.Save();
            return _mapper.Map<ZorgkundigeShiftDTO>(zorgkundigeToUpdate);
        }
    }
}
