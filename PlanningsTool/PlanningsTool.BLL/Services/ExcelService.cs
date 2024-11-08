﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using PlanningsTool.Common.DTO.NurseShifts;
using PlanningsTool.Common.DTO.Vacations;
using PlanningsTool.Common.DTO.Holidays;
using PlanningsTool.BLL.Interfaces;

public class ExcelService : IExcelService
{
    public ExcelService()
    {
    }

    public void GenerateExcel(IEnumerable<NurseShiftDTO> nurseShifts, IEnumerable<VacationDTO> vacations, IEnumerable<HolidayDTO> holidays, string filePath, int teamplanId)
    {
        var teamplan = nurseShifts.FirstOrDefault(ns => ns.TeamplanId == teamplanId)?.Teamplan;
        if (teamplan == null) throw new Exception("Teamplan not found.");

        var startDate = new DateTime(teamplan.PlanFor.Year, teamplan.PlanFor.Month, 1);
        var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

        var filteredNurseShifts = nurseShifts.Where(ns => ns.TeamplanId == teamplanId).ToList();

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Nurse Schedule");

            // Create headers
            worksheet.Cells[1, 1].Value = "Nurse";
            for (int day = 1; day <= daysInMonth; day++)
            {
                worksheet.Cells[1, day + 1].Value = day.ToString();
            }

            // Create nurse schedule data
            var row = 2;
            foreach (var nurseGroup in filteredNurseShifts.GroupBy(n => n.NurseId))
            {
                var nurse = nurseGroup.First().Nurse;
                worksheet.Cells[row, 1].Value = $"{nurse.FirstName} {nurse.LastName}";

                foreach (var shift in nurseGroup)
                {
                    var shiftDate = shift.Date.Date;
                    if (shiftDate.Month == startDate.Month && shiftDate.Year == startDate.Year)
                    {
                        worksheet.Cells[row, shiftDate.Day + 1].Value = shift.Shift.ShiftType.Name;
                    }
                }

                foreach (var vacation in vacations.Where(v => v.NurseId == nurseGroup.Key))
                {
                    var startDateVacation = vacation.Startdate.Date;
                    var endDateVacation = vacation.Enddate.Date;
                    for (var date = startDateVacation; date <= endDateVacation; date = date.AddDays(1))
                    {
                        if (date.Month == startDate.Month && date.Year == startDate.Year)
                        {
                            worksheet.Cells[row, date.Day + 1].Value = vacation.VacationType.Name;
                        }
                    }
                }

                row++;
            }

            // Save the file
            package.SaveAs(new FileInfo(filePath));
        }
    }
}
