using PlanningsTool.DAL.Repositories;

namespace PlanningsTool.DAL.UOW
{
    public interface IUnitOfWork
    {
        public IHolidaysRepository HolidaysRepository { get; }
        public INursesRepository NursesRepository { get; }
        public INurseShiftsRepository NurseShiftsRepository { get; }
        public IShiftsRepository ShiftsRepository { get; }
        public ITeamsRepository TeamsRepository { get; }
        public ITeamplansRepository TeamplansRepository { get; }
        public IRegimeTypesRepository RegimeTypesRepository { get; }
        public IShiftTypesRepository ShiftTypesRepository { get; }
        public IVacationTypesRepository VacationTypesRepository { get; }        
        public IVacationsRepository VacationsRepository { get; }
        Task Save();
    }
}