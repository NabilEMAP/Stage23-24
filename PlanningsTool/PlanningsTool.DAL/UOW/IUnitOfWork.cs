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
        public IRegimeTypesRepository RegimeTypesRepository { get; }
        public IVerlofTypesRepository VerlofTypesRepository { get; }
        public IShiftTypesRepository ShiftTypesRepository { get; }
        public IVerlovenRepository VerlovenRepository { get; }
        public IShiftsRepository ShiftsRepository { get; }
        public IZorgkundigeShiftsRepository ZorgkundigeShiftsRepository { get; }
        public ITeamplanningenRepository TeamplanningenRepository { get; }
        Task Save();
    }
}
