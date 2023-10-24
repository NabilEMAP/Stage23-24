﻿using PlanningsTool.Common.DTO.VerlofTypes;
using PlanningsTool.Common.DTO.Zorgkundigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.Common.DTO.Verloven
{
    public class CreateVerlofDTO
    {
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string Reden { get; set; }
        public int ZorgkundigeId { get; set; }
        public int VerlofTypeId { get; set; }
    }
}
