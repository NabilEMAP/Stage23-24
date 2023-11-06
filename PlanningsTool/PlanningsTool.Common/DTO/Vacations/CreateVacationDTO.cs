namespace PlanningsTool.Common.DTO.Vacations
{
    public class CreateVacationDTO
    {
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Reason { get; set; }
        public int NurseId { get; set; }
        public int VacationTypeId { get; set; }
    }
}
