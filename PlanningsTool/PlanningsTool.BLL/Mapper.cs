using AutoMapper;
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
        }
    }
}
