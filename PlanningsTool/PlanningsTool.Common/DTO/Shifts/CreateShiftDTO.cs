namespace PlanningsTool.Common.DTO.Shifts
{
    public class CreateShiftDTO
    {
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public int ShiftTypeId { get; set; }
    }
}
