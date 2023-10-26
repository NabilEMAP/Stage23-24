using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.Common.DTO.Teamplanningen;
using PlanningsTool.Common.DTO.Zorgkundigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.ZorgkundigeShifts
{
    public class ZorgkundigeShiftDTO
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int ZorgkundigeId { get; set; }
        public ZorgkundigeDTO Zorgkundige { get; set; }
        public int ShiftId { get; set; }
        public ShiftDTO Shift { get; set; }
        public int TeamplanningId { get; set; }
        public TeamplanningDTO Teamplanning { get; set; }
    }
}
