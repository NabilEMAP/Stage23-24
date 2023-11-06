using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.Common.DTO.Teamplans;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.Common.DTO.NurseShifts
{
    public class NurseShiftDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NurseId { get; set; }
        public NurseDTO Nurse { get; set; }
        public int ShiftId { get; set; }
        public ShiftDTO Shift { get; set; }
        public int TeamplanId { get; set; }
        public TeamplanDTO Teamplan { get; set; }
    }
}
