using PlanningsTool.Common.DTO.Shifts;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IShiftsService
    {
        public Task<IEnumerable<ShiftDTO>> GetAll();
        public Task<ShiftDTO> GetById(int id);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByStarttime(string starttime);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByEndtime(string endtime);
    }
}
