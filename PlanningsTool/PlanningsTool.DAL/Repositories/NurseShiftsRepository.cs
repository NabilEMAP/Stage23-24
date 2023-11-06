using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Contexts;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Repositories
{
    public class NurseShiftsRepository : GenericRepository<NurseShift>, INurseShiftsRepository
    {
        public NurseShiftsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NurseShift>> GetAllNurseShiftsAsync()
        {
            return await _context.NurseShifts
                .Include(n => n.Nurse)
                .Include(s => s.Shift)
                .Include(t => t.Teamplan)
                .Include(st => st.Shift.ShiftType)
                .Include(nr => nr.Nurse.RegimeType)
                .ToListAsync();
        }

        public async Task<NurseShift> GetNurseShiftAsyncById(int id)
        {
            return await _context.NurseShifts
                .Include(n => n.Nurse)
                .Include(s => s.Shift)
                .Include(t => t.Teamplan)
                .Include(st => st.Shift.ShiftType)
                .Include(nr => nr.Nurse.RegimeType)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<NurseShift>> GetNurseShiftsByDate(string date)
        {
            string query = $"SELECT * FROM [dbo].[NurseShifts] AS z WHERE z.Date like '%{date}%'";
            return await _context.NurseShifts
                .FromSqlRaw(query)
                .Include(n => n.Nurse)
                .Include(s => s.Shift)
                .Include(t => t.Teamplan)
                .Include(st => st.Shift.ShiftType)
                .Include(nr => nr.Nurse.RegimeType)
                .ToListAsync();
        }
    }
}
