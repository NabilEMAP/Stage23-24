using PlanningsTool.Common.DTO.Shifts;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IShiftsService
    {
        public Task<IEnumerable<ShiftDTO>> GetAll();
        public Task<ShiftDTO> GetById(int id);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByStarttime(string starttime);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByEndtime(string endtime);
        public Task<ShiftDTO> Add(CreateShiftDTO shift);
        public Task<ShiftDTO> Update(int id, UpdateShiftDTO shift);
        public Task<int> Delete(int id);
    }
}
