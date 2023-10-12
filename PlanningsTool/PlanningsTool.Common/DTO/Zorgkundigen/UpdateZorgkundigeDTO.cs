using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.Zorgkundigen
{
    public class UpdateZorgkundigeDTO
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool IsVasteNacht { get; set; }
    }
}
