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

        public UnitOfWork(
            ApplicationDbContext context,
            IZorgkundigenRepository zorgkundigenRepository,
            IRegimeTypesRepository regimeTypesRepository
            )
        {
            _context = context;
            _zorgkundigenRepository = zorgkundigenRepository;
            _regimeTypesRepository = regimeTypesRepository;
        }

        public IZorgkundigenRepository ZorgkundigenRepository { get { return _zorgkundigenRepository; } }
        public IRegimeTypesRepository RegimeTypesRepository { get { return _regimeTypesRepository; } }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
