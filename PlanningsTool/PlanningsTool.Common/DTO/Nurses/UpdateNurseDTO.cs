namespace PlanningsTool.Common.DTO.Nurses
{
    public class UpdateNurseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegimeTypeId { get; set; }
        public bool IsFixedNight { get; set; }
    }
}
