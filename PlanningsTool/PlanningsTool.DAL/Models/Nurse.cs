namespace PlanningsTool.DAL.Models
{
    public class Nurse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegimeTypeId { get; set; }
        public RegimeType RegimeType { get; set; }
        public bool? IsFixedNight { get; set; }
    }
}
