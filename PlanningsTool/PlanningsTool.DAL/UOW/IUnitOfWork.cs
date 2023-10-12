using PlanningsTool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.UOW
{
    public interface IUnitOfWork
    {
        public IZorgkundigenRepository ZorgkundigenRepository { get; }
        Task Save();
    }
}
