using Microsoft.AspNetCore.Mvc;
using PlanningsTool.BLL.Interfaces;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ExcelController : ControllerBase
{
    private readonly INurseShiftsService _nurseShiftsService;
    private readonly IVacationsService _vacationsService;
    private readonly IHolidaysService _holidaysService;
    private readonly IExcelService _excelService;

    public ExcelController(INurseShiftsService nurseShiftsService, IVacationsService vacationsService, IHolidaysService holidaysService, IExcelService excelService)
    {
        _nurseShiftsService = nurseShiftsService;
        _vacationsService = vacationsService;
        _holidaysService = holidaysService;
        _excelService = excelService;
    }

    // POST api/Excel
    /// <summary>
    /// Generates an Excel by the teamplanId for a specified month and year.
    /// </summary>
    /// <param name="teamplanId">The teamplanId for which the Excel is generated.</param>
    /// <returns></returns>
    [HttpGet("generate")]
    public async Task<IActionResult> GenerateExcel([FromQuery] int teamplanId)
    {
        var nurseShifts = await _nurseShiftsService.GetAll();
        var vacations = await _vacationsService.GetAll();
        var holidays = await _holidaysService.GetAll();

        string filePath = Path.Combine(Path.GetTempPath(), "NurseSchedule.xlsx");
        _excelService.GenerateExcel(nurseShifts, vacations, holidays, filePath, teamplanId);

        byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NurseSchedule.xlsx");
    }
}
