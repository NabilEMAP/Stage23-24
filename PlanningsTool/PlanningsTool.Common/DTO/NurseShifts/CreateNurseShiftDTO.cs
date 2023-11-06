namespace PlanningsTool.Common.DTO.NurseShifts
{
    public class CreateNurseShiftDTO
    {
        public DateTime Date { get; set; }
        public int NurseId { get; set; }
        public int ShiftId { get; set; }
        public int TeamplanId { get; set; }
    }
}
