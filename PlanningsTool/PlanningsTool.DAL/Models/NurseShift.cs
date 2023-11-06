namespace PlanningsTool.DAL.Models
{
    public class NurseShift
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NurseId {  get; set; }
        public Nurse Nurse {  get; set; }
        public int ShiftId {  get; set; }
        public Shift Shift {  get; set; }
        public int TeamplanId {  get; set; }
        public Teamplan Teamplan {  get; set; }
    }
}
