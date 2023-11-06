namespace PlanningsTool.DAL.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Reason {  get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
    }
}
