namespace PlanningsTool.DAL.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public int ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; }
    }
}
