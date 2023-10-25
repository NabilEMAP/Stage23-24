using PlanningsTool.Common.DTO.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IShiftsService
    {
        public Task<IEnumerable<ShiftDTO>> GetAll();
        public Task<ShiftDTO> GetById(int id);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByStarttijd(string starttijd);
        public Task<IEnumerable<ShiftDTO>> GetShiftsByEindtijd(string eindtijd);
        public Task<ShiftDTO> Add(CreateShiftDTO entity);
        public Task<ShiftDTO> Update(int id, UpdateShiftDTO entity);
        public Task<int> Delete(int id);
    }
}
