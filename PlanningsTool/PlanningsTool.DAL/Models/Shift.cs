using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public TimeSpan Starttijd { get; set; }
        public TimeSpan Eindtijd { get; set; }
        public int ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; }
    }
}
