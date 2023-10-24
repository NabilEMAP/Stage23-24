using PlanningsTool.Common.DTO.ShiftTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IShiftTypesService
    {
        public Task<IEnumerable<ShiftTypeDTO>> GetAll();
        public Task<ShiftTypeDTO> GetById(int id);
        public Task<IEnumerable<ShiftTypeDTO>> GetShiftTypesByNaam(string naam);
    }
}
