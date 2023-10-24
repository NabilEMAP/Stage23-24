using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public readonly IZorgkundigenRepository _zorgkundigenRepository;
        public readonly IRegimeTypesRepository _regimeTypesRepository;
        public readonly IVerlofTypesRepository _verlofTypesRepository;
        public readonly IShiftTypesRepository _shiftTypesRepository;

        public UnitOfWork(
            ApplicationDbContext context,
            IZorgkundigenRepository zorgkundigenRepository,
            IRegimeTypesRepository regimeTypesRepository,
            IVerlofTypesRepository verlofTypesRepository,
            IShiftTypesRepository shiftTypesRepository
            )
        {
            _context = context;
            _zorgkundigenRepository = zorgkundigenRepository;
            _regimeTypesRepository = regimeTypesRepository;
            _verlofTypesRepository = verlofTypesRepository;
            _shiftTypesRepository = shiftTypesRepository;
        }

        public IZorgkundigenRepository ZorgkundigenRepository { get { return _zorgkundigenRepository; } }
        public IRegimeTypesRepository RegimeTypesRepository { get { return _regimeTypesRepository; } }
        public IVerlofTypesRepository VerlofTypesRepository { get { return _verlofTypesRepository; } }
        public IShiftTypesRepository ShiftTypesRepository { get { return _shiftTypesRepository; } }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
