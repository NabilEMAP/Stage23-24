namespace PlanningsTool.Common.DTO.Nurses
{
    public class CreateNurseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegimeTypeId { get; set; }
        public bool IsFixedNight { get; set; }
        public int TeamId { get; set; }
    }
}
