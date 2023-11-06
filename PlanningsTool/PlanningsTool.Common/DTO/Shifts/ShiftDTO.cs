using PlanningsTool.Common.DTO.ShiftTypes;

namespace PlanningsTool.Common.DTO.Shifts
{
    public class ShiftDTO
    {
        public int Id { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public int ShiftTypeId { get; set; }
        public ShiftTypeDTO ShiftType { get; set; }
    }
}
