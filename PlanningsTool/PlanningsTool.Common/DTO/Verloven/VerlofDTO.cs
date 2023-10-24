using PlanningsTool.Common.DTO.VerlofTypes;
using PlanningsTool.Common.DTO.Zorgkundigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.Verloven
{
    public class VerlofDTO
    {
        public int Id { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int ZorgkundigeId { get; set; }
        public ZorgkundigeDetailDTO Zorgkundige { get; set; }
        public int VerlofTypeId { get; set; }
        public VerlofTypeDTO VerlofType { get; set; }
    }
}
