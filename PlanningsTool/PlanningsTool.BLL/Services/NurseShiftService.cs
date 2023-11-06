using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.NurseShifts;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;

namespace PlanningsTool.BLL.Services
{
    public class NurseShiftService : INurseShiftsService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public NurseShiftService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<NurseShiftDTO> Add(CreateNurseShiftDTO entity)
        {
            var nurse = _mapper.Map<NurseShift>(entity);
            await _uow.NurseShiftsRepository.Add(nurse);
            await _uow.Save();
            return _mapper.Map<NurseShiftDTO>(nurse);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteZorgkundige = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);
            if (toDeleteZorgkundige == null)
            {
                throw new KeyNotFoundException("This nurse shift does not exist.");
            }
            _uow.NurseShiftsRepository.Delete(toDeleteZorgkundige);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<NurseShiftDTO>> GetAll()
        {
            var nurses = await _uow.NurseShiftsRepository.GetAllNurseShiftsAsync();
            return _mapper.Map<IEnumerable<NurseShiftDTO>>(nurses);
        }

        public async Task<NurseShiftDTO> GetById(int id)
        {
            var nurse = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);
            return _mapper.Map<NurseShiftDTO>(nurse);
        }

        public async Task<IEnumerable<NurseShiftDTO>> GetNurseShiftsByDate(string date)
        {
            var nurses = await _uow.NurseShiftsRepository.GetNurseShiftsByDate(date);
            return _mapper.Map<IEnumerable<NurseShiftDTO>>(nurses);
        }

        public async Task<NurseShiftDTO> Update(int id, UpdateNurseShiftDTO entity)
        {
            var nurseFromRequest = _mapper.Map<NurseShift>(entity);
            var nurseToUpdate = await _uow.NurseShiftsRepository.GetNurseShiftAsyncById(id);

            if (nurseToUpdate == null)
            {
                throw new KeyNotFoundException("Deze nurse shift bestaat niet.");
            }

            nurseToUpdate.Date = nurseFromRequest.Date;
            nurseToUpdate.NurseId = nurseFromRequest.NurseId;
            nurseToUpdate.ShiftId = nurseFromRequest.ShiftId;
            nurseToUpdate.TeamplanId = nurseFromRequest.TeamplanId;

            await _uow.NurseShiftsRepository.Update(nurseToUpdate);
            await _uow.Save();
            return _mapper.Map<NurseShiftDTO>(nurseToUpdate);
        }
    }
}
