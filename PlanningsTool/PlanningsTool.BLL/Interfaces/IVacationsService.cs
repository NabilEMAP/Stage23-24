using PlanningsTool.Common.DTO.Vacations;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IVacationsService
    {
        public Task<IEnumerable<VacationDTO>> GetAll();
        public Task<IEnumerable<VacationDetailDTO>> GetAllDetails();
        public Task<VacationDetailDTO> GetById(int id);
        public Task<IEnumerable<VacationDetailDTO>> GetVacationsByStartdate(string stardate);
        public Task<IEnumerable<VacationDetailDTO>> GetVacationsByEnddate(string enddate);
        public Task<IEnumerable<VacationDetailDTO>> GetVacationsByReason(string reason);
        public Task<VacationDetailDTO> Add(CreateVacationDTO vacation);
        public Task<VacationDetailDTO> Update(int id, UpdateVacationDTO vacation);
        public Task<int> Delete(int id);
    }
}
