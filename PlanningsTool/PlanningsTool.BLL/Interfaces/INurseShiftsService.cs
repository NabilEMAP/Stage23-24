using PlanningsTool.Common.DTO.NurseShifts;

namespace PlanningsTool.BLL.Interfaces
{
    public interface INurseShiftsService
    {
        public Task<IEnumerable<NurseShiftDTO>> GetAll();
        public Task<NurseShiftDTO> GetById(int id);
        public Task<IEnumerable<NurseShiftDTO>> GetNurseShiftsByDate(string date);
        public Task<NurseShiftDTO> Add(CreateNurseShiftDTO nurseShift);
        public Task<NurseShiftDTO> Update(int id, UpdateNurseShiftDTO nurseShift);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfExist(int nurseId, int shiftId, DateTime date);
        public Task<bool> CheckIfExist(int id, int nurseId, int shiftId, DateTime date);
    }
}
