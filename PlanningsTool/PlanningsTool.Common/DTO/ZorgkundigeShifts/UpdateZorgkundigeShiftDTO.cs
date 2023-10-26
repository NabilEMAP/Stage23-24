using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.ZorgkundigeShifts
{
    public class UpdateZorgkundigeShiftDTO
    {
        public DateTime Datum { get; set; }
        public int ZorgkundigeId { get; set; }
        public int ShiftId { get; set; }
        public int TeamplanningId { get; set; }
    }
}
