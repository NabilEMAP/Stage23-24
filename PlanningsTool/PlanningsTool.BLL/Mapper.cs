using AutoMapper;
using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.Common.DTO.VerlofTypes;
using PlanningsTool.Common.DTO.Verloven;
using PlanningsTool.Common.DTO.Zorgkundigen;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Zorgkundige, ZorgkundigeDTO>().ReverseMap();
            CreateMap<Zorgkundige, ZorgkundigeDetailDTO>().ReverseMap();
            CreateMap<Zorgkundige, CreateZorgkundigeDTO>().ReverseMap();
            CreateMap<Zorgkundige, UpdateZorgkundigeDTO>().ReverseMap();

            CreateMap<Verlof, VerlofDTO>().ReverseMap();
            CreateMap<Verlof, VerlofDetailDTO>().ReverseMap();
            CreateMap<Verlof, CreateVerlofDTO>().ReverseMap();
            CreateMap<Verlof, UpdateVerlofDTO>().ReverseMap();

            CreateMap<RegimeType, RegimeTypeDTO>().ReverseMap();
            CreateMap<VerlofType, VerlofTypeDTO>().ReverseMap();
            CreateMap<ShiftType, ShiftTypeDTO>().ReverseMap();
        }
    }
}
