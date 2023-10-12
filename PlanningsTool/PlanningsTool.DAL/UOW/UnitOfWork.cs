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

        public UnitOfWork(ApplicationDbContext context, IZorgkundigenRepository zorgkundigenRepository)
        {
            _context = context;
            _zorgkundigenRepository = zorgkundigenRepository;
        }

        public IZorgkundigenRepository ZorgkundigenRepository { get { return _zorgkundigenRepository; } }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
