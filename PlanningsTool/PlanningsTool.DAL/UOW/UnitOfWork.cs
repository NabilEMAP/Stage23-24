using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Repositories;

namespace PlanningsTool.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public readonly IHolidaysRepository _holidaysRepository;
        public readonly INursesRepository _nursesRepository;
        public readonly INurseShiftsRepository _nurseShiftsRepository;
        public readonly IShiftsRepository _shiftsRepository;
        public readonly ITeamsRepository _teamsRepository;
        public readonly ITeamplansRepository _teamplansRepository;
        public readonly IRegimeTypesRepository _regimeTypesRepository;
        public readonly IShiftTypesRepository _shiftTypesRepository;
        public readonly IVacationTypesRepository _vacationTypesRepository;
        public readonly IVacationsRepository _vacationsRepository;

        public UnitOfWork(
            ApplicationDbContext context,
            IHolidaysRepository holidaysRepository,
            INursesRepository nursesRepository,
            INurseShiftsRepository nurseShiftsRepository,
            IShiftsRepository shiftsRepository,
            ITeamsRepository teamsRepository,
            ITeamplansRepository teamplansRepository,
            IRegimeTypesRepository regimeTypesRepository,
            IShiftTypesRepository shiftTypesRepository,
            IVacationTypesRepository vacationTypesRepository,            
            IVacationsRepository vacationsRepository
            )
        {
            _context = context;
            _holidaysRepository = holidaysRepository;
            _nursesRepository = nursesRepository;
            _nurseShiftsRepository = nurseShiftsRepository;
            _shiftsRepository = shiftsRepository;
            _teamsRepository = teamsRepository;
            _teamplansRepository = teamplansRepository;
            _regimeTypesRepository = regimeTypesRepository;
            _shiftTypesRepository = shiftTypesRepository;
            _vacationTypesRepository = vacationTypesRepository;
            _vacationsRepository = vacationsRepository;
        }

        public IHolidaysRepository HolidaysRepository { get { return _holidaysRepository; } }
        public INursesRepository NursesRepository { get { return _nursesRepository; } }
        public INurseShiftsRepository NurseShiftsRepository { get { return _nurseShiftsRepository; } }
        public IShiftsRepository ShiftsRepository { get { return _shiftsRepository; } }
        public ITeamsRepository TeamsRepository { get { return _teamsRepository; } }
        public ITeamplansRepository TeamplansRepository { get { return _teamplansRepository; } }
        public IRegimeTypesRepository RegimeTypesRepository { get { return _regimeTypesRepository; } }
        public IShiftTypesRepository ShiftTypesRepository { get { return _shiftTypesRepository; } }
        public IVacationTypesRepository VacationTypesRepository { get { return _vacationTypesRepository; } }
        public IVacationsRepository VacationsRepository { get { return _vacationsRepository; } }
        

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}