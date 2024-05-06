using PlanningsTool.DAL.Repositories;

namespace PlanningsTool.DAL.UOW
{
    public interface IUnitOfWork
    {
        public INursesRepository NursesRepository { get; }
        public IRegimeTypesRepository RegimeTypesRepository { get; }
        public IVacationTypesRepository VacationTypesRepository { get; }
        public IShiftTypesRepository ShiftTypesRepository { get; }
        public IVacationsRepository VacationsRepository { get; }
        public IShiftsRepository ShiftsRepository { get; }
        public INurseShiftsRepository NurseShiftsRepository { get; }
        public ITeamsRepository TeamsRepository { get; }
        public ITeamplansRepository TeamplansRepository { get; }
        public IHolidaysRepository HolidaysRepository { get; }
        Task Save();
    }
}