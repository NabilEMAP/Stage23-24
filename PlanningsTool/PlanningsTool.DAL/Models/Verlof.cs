using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class Verlof
    {
        public int Id { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Reden {  get; set; }
        public int ZorgkundigeId { get; set; }
        public Zorgkundige Zorgkundige { get; set; }
        public int VerlofTypeId { get; set; }
        public VerlofType VerlofType { get; set; }
    }
}
