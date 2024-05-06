using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.Common.DTO.Teams;

namespace PlanningsTool.Common.DTO.Nurses
{
    public class NurseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegimeTypeId { get; set; }
        public RegimeTypeDTO RegimeType { get; set; }
        public bool IsFixedNight { get; set; }
        public int TeamId { get; set; }
        public TeamDTO Team { get; set; }
    }
}
