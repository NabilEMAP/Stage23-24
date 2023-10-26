using AutoMapper;
using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.Common.DTO.Teamplanningen;
using PlanningsTool.Common.DTO.VerlofTypes;
using PlanningsTool.Common.DTO.Verloven;
using PlanningsTool.Common.DTO.Zorgkundigen;
using PlanningsTool.Common.DTO.ZorgkundigeShifts;
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
            CreateMap<Zorgkundige, CreateZorgkundigeDTO>().ReverseMap();
            CreateMap<Zorgkundige, UpdateZorgkundigeDTO>().ReverseMap();

            CreateMap<Verlof, VerlofDTO>().ReverseMap();
            CreateMap<Verlof, VerlofDetailDTO>().ReverseMap();
            CreateMap<Verlof, CreateVerlofDTO>().ReverseMap();
            CreateMap<Verlof, UpdateVerlofDTO>().ReverseMap();

            CreateMap<Shift, ShiftDTO>().ReverseMap();
            CreateMap<Shift, CreateShiftDTO>().ReverseMap();
            CreateMap<Shift, UpdateShiftDTO>().ReverseMap();

            CreateMap<ZorgkundigeShift, ZorgkundigeShiftDTO>().ReverseMap();
            CreateMap<ZorgkundigeShift, CreateZorgkundigeShiftDTO>().ReverseMap();
            CreateMap<ZorgkundigeShift, UpdateZorgkundigeShiftDTO>().ReverseMap();

            CreateMap<Teamplanning, TeamplanningDTO>().ReverseMap();
            CreateMap<Teamplanning, CreateTeamplanningDTO>().ReverseMap();
            CreateMap<Teamplanning, UpdateTeamplanningDTO>().ReverseMap();

            CreateMap<RegimeType, RegimeTypeDTO>().ReverseMap();
            CreateMap<VerlofType, VerlofTypeDTO>().ReverseMap();
            CreateMap<ShiftType, ShiftTypeDTO>().ReverseMap();
        }
    }
}
