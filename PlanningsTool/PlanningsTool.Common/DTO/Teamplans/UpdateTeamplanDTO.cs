using PlanningsTool.Common.DTO.Teams;

namespace PlanningsTool.Common.DTO.Teamplans
{
    public class UpdateTeamplanDTO
    {
        public string Name { get; set; }
        public DateTime PlanFor { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TeamId { get; set; }
    }
}
