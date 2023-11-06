namespace PlanningsTool.Common.DTO.Shifts
{
    public class UpdateShiftDTO
    {
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public int ShiftTypeId { get; set; }
    }
}
