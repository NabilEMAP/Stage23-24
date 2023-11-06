using PlanningsTool.Common.DTO.VacationTypes;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IVacationTypesService
    {
        public Task<IEnumerable<VacationTypeDTO>> GetAll();
        public Task<VacationTypeDTO> GetById(int id);
        public Task<IEnumerable<VacationTypeDTO>> GetVacationTypesByName(string name);
    }
}
