using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class Zorgkundige
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int RegimeId { get; set; }
        public RegimeType RegimeType { get; set; }
        public bool? IsVasteNacht { get; set; }
    }
}
