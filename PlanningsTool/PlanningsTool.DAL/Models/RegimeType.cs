using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class RegimeType
    {
        public int Id { get; set; }
        public string Regime { get; set; }
        public decimal AantalUren { get; set; }
    }
}
