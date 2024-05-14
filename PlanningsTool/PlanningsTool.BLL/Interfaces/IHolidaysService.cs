using PlanningsTool.Common.DTO.Holidays;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IHolidaysService
    {
        public Task<IEnumerable<HolidayDTO>> GetAll();
        public Task<HolidayDTO> GetById(int id);
        public Task<IEnumerable<HolidayDTO>> GetHolidaysByName(string name);
        public Task<IEnumerable<HolidayDTO>> GetHolidaysByDate(string date);
        public Task<int> Generate(int year);
        public Task<int> ClearAll();
        public Task<HolidayDTO> Add(CreateHolidayDTO entity);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfGeneratedYearExist(int year);
        public Task<HolidayDTO> Update(int id, UpdateHolidayDTO entity);
    }
}
