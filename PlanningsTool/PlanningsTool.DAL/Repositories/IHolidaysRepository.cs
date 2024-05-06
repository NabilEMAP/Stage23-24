using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public interface IHolidaysRepository : IGenericRepository<Holiday>
    {
        Task<IEnumerable<Holiday>> GetAllHolidaysAsync();
        Task<Holiday> GetHolidayAsyncById(int id);
        Task AddHolidaysByYear(int year);
        Task<IEnumerable<Holiday>> GetHolidaysByName(string name);
        Task<IEnumerable<Holiday>> GetHolidaysByDate(string date);
        Task<IEnumerable<Holiday>> GetHolidayByYear(int year);
    }
}
