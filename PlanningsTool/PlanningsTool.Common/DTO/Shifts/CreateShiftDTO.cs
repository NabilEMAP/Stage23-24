using PlanningsTool.Common.DTO.ShiftTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.Shifts
{
    public class CreateShiftDTO
    {
        public TimeSpan Starttijd { get; set; }
        public TimeSpan Eindtijd { get; set; }
        public int ShiftTypeId { get; set; }
    }
}
