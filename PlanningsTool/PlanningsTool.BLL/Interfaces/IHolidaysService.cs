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
        public Task<HolidayDTO> Update(int id, UpdateHolidayDTO entity);
        public Task<int> Delete(int id);
        public Task<bool> CheckIfYearExist(int year);
        public Task<bool> CheckIfExist(string name, DateTime date);
        public Task<bool> CheckIfExist(int id, string name, DateTime date);
    }
}
