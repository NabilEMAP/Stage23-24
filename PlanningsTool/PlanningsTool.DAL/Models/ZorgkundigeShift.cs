using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class ZorgkundigeShift
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int ZorgkundigeId {  get; set; }
        public Zorgkundige Zorgkundige {  get; set; }
        public int ShiftId {  get; set; }
        public Shift Shift {  get; set; }
        public int TeamplanningId {  get; set; }
        public Teamplanning Teamplanning {  get; set; }
    }
}
