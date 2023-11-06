using PlanningsTool.Common.DTO.ShiftTypes;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IShiftTypesService
    {
        public Task<IEnumerable<ShiftTypeDTO>> GetAll();
        public Task<ShiftTypeDTO> GetById(int id);
        public Task<IEnumerable<ShiftTypeDTO>> GetShiftTypesByName(string name);
    }
}
