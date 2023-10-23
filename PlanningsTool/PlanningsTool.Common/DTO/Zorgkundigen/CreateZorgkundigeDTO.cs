using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.Zorgkundigen
{
    public class CreateZorgkundigeDTO
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int RegimeId { get; set; }
        public bool IsVasteNacht { get; set; }
    }
}
