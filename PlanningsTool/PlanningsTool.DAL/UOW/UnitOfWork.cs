using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Repositories;

namespace PlanningsTool.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public readonly INursesRepository _nursesRepository;
        public readonly IRegimeTypesRepository _regimeTypesRepository;
        public readonly IVacationTypesRepository _vacationTypesRepository;
        public readonly IShiftTypesRepository _shiftTypesRepository;
        public readonly IVacationsRepository _vacationsRepository;
        public readonly IShiftsRepository _shiftsRepository;
        public readonly INurseShiftsRepository _nurseShiftsRepository;
        public readonly ITeamplansRepository _teamplansRepository;
        public readonly IHolidaysRepository _holidaysRepository;

        public UnitOfWork(
            ApplicationDbContext context,
            INursesRepository nursesRepository,
            IRegimeTypesRepository regimeTypesRepository,
            IVacationTypesRepository vacationTypesRepository,
            IShiftTypesRepository shiftTypesRepository,
            IVacationsRepository vacationsRepository,
            IShiftsRepository shiftsRepository,
            INurseShiftsRepository nurseShiftsRepository,
            ITeamplansRepository teamplansRepository,
            IHolidaysRepository holidaysRepository
            )
        {
            _context = context;
            _nursesRepository = nursesRepository;
            _regimeTypesRepository = regimeTypesRepository;
            _vacationTypesRepository = vacationTypesRepository;
            _shiftTypesRepository = shiftTypesRepository;
            _vacationsRepository = vacationsRepository;
            _shiftsRepository = shiftsRepository;
            _nurseShiftsRepository = nurseShiftsRepository;
            _teamplansRepository = teamplansRepository;
            _holidaysRepository = holidaysRepository;
        }

        public INursesRepository NursesRepository { get { return _nursesRepository; } }
        public IRegimeTypesRepository RegimeTypesRepository { get { return _regimeTypesRepository; } }
        public IVacationTypesRepository VacationTypesRepository { get { return _vacationTypesRepository; } }
        public IShiftTypesRepository ShiftTypesRepository { get { return _shiftTypesRepository; } }
        public IVacationsRepository VacationsRepository { get { return _vacationsRepository; } }
        public IShiftsRepository ShiftsRepository { get { return _shiftsRepository; } }
        public INurseShiftsRepository NurseShiftsRepository { get { return _nurseShiftsRepository; } }
        public ITeamplansRepository TeamplansRepository { get { return _teamplansRepository; } }
        public IHolidaysRepository HolidaysRepository { get { return _holidaysRepository; } }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
