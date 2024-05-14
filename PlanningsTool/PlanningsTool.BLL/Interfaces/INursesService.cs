using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.BLL.Interfaces
{
    public interface INursesService
    {
        public Task<IEnumerable<NurseDTO>> GetAll();
        public Task<NurseDTO> GetById(int id);
        public Task<IEnumerable<NurseDTO>> GetNursesByFirstName(string firstName);
        public Task<IEnumerable<NurseDTO>> GetNursesByLastName(string lastName);
        public Task<NurseDTO> Add(CreateNurseDTO nurse);
        public Task<NurseDTO> Update(int id, UpdateNurseDTO nurse);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfExist(string firstName, string lastName);
        public Task<bool> CheckIfExist(int id, string firstName, string lastName);
    }
}
