using AutoMapper;
using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.Common.DTO.Nurses;
using PlanningsTool.Common.DTO.NurseShifts;
using PlanningsTool.Common.DTO.Shifts;
using PlanningsTool.Common.DTO.Teams;
using PlanningsTool.Common.DTO.Teamplans;
using PlanningsTool.Common.DTO.RegimeTypes;
using PlanningsTool.Common.DTO.ShiftTypes;
using PlanningsTool.Common.DTO.VacationTypes;
using PlanningsTool.Common.DTO.Vacations;

using PlanningsTool.DAL.Models;

namespace PlanningsTool.BLL
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Holiday, HolidayDTO>().ReverseMap();
            CreateMap<Holiday, CreateHolidayDTO>().ReverseMap();

            CreateMap<Nurse, NurseDTO>().ReverseMap();
            CreateMap<Nurse, CreateNurseDTO>().ReverseMap();
            CreateMap<Nurse, UpdateNurseDTO>().ReverseMap();

            CreateMap<NurseShift, NurseShiftDTO>().ReverseMap();
            CreateMap<NurseShift, CreateNurseShiftDTO>().ReverseMap();
            CreateMap<NurseShift, UpdateNurseShiftDTO>().ReverseMap();

            CreateMap<Shift, ShiftDTO>().ReverseMap();

            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<Team, CreateTeamDTO>().ReverseMap();
            CreateMap<Team, UpdateTeamDTO>().ReverseMap();

            CreateMap<Teamplan, TeamplanDTO>().ReverseMap();
            CreateMap<Teamplan, CreateTeamplanDTO>().ReverseMap();
            CreateMap<Teamplan, UpdateTeamplanDTO>().ReverseMap();

            CreateMap<RegimeType, RegimeTypeDTO>().ReverseMap();
            CreateMap<ShiftType, ShiftTypeDTO>().ReverseMap();
            CreateMap<VacationType, VacationTypeDTO>().ReverseMap();

            CreateMap<Vacation, VacationDTO>().ReverseMap();
            CreateMap<Vacation, VacationDetailDTO>().ReverseMap();
            CreateMap<Vacation, CreateVacationDTO>().ReverseMap();
            CreateMap<Vacation, UpdateVacationDTO>().ReverseMap();
        }
    }
}
