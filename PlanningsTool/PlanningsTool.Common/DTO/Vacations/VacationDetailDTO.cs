using PlanningsTool.Common.DTO.VacationTypes;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.Common.DTO.Vacations
{
    public class VacationDetailDTO
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Reason { get; set; }
        public int NurseId { get; set; }
        public NurseDTO Nurse { get; set; }
        public int VacationTypeId { get; set; }
        public VacationTypeDTO VacationType { get; set; }
    }
}
