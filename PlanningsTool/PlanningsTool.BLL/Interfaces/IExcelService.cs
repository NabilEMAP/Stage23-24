using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.Common.DTO.NurseShifts;
using PlanningsTool.Common.DTO.Vacations;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IExcelService
    {
        public void GenerateExcel(
            IEnumerable<NurseShiftDTO> nurseShifts,
            IEnumerable<VacationDTO> vacations,
            IEnumerable<HolidayDTO> holidays,
            string filePath,
            int teamplanId
            );
    }
}
