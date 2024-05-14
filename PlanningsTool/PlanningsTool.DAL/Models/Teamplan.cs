namespace PlanningsTool.DAL.Models
{
    public class Teamplan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PlanFor { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
