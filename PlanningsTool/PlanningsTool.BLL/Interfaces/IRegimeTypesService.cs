using PlanningsTool.Common.DTO.RegimeTypes;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IRegimeTypesService
    {
        public Task<IEnumerable<RegimeTypeDTO>> GetAll();
        public Task<RegimeTypeDTO> GetById(int id);
        public Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByName(string name);
        public Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByCountHours(string countHours);
    }
}
