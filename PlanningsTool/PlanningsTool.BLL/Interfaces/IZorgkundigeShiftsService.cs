using PlanningsTool.Common.DTO.Zorgkundigen;
using PlanningsTool.Common.DTO.ZorgkundigeShifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IZorgkundigeShiftsService
    {
        public Task<IEnumerable<ZorgkundigeShiftDTO>> GetAll();
        public Task<ZorgkundigeShiftDTO> GetById(int id);
        public Task<IEnumerable<ZorgkundigeShiftDTO>> GetZorgkundigeShiftsByDatum(string datum);
        public Task<ZorgkundigeShiftDTO> Add(CreateZorgkundigeShiftDTO zorgkundigeShift);
        public Task<ZorgkundigeShiftDTO> Update(int id, UpdateZorgkundigeShiftDTO zorgkundigeShift);
        public Task<int> Delete(int id);
    }
}
