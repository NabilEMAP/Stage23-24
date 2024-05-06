using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Configurations;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.Seeding;
using System.Reflection;

namespace PlanningsTool.DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<NurseShift> NurseShifts { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Teamplan> Teamplans { get; set; }
        public virtual DbSet<RegimeType> RegimeTypes { get; set; }        
        public virtual DbSet<ShiftType> ShiftTypes { get; set; }
        public virtual DbSet<VacationType> VacationTypes { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HolidayConfiguration());
            modelBuilder.ApplyConfiguration(new NurseConfiguration());
            modelBuilder.ApplyConfiguration(new NurseShiftConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamplanConfiguration());
            modelBuilder.ApplyConfiguration(new RegimeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VacationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VacationConfiguration());
            modelBuilder.Entity<Holiday>().Seed();
            modelBuilder.Entity<Nurse>().Seed();
            modelBuilder.Entity<NurseShift>().Seed();
            modelBuilder.Entity<Shift>().Seed();
            modelBuilder.Entity<Team>().Seed();
            modelBuilder.Entity<Teamplan>().Seed();
            modelBuilder.Entity<RegimeType>().Seed();
            modelBuilder.Entity<ShiftType>().Seed();
            modelBuilder.Entity<VacationType>().Seed();
            modelBuilder.Entity<Vacation>().Seed();
        }
    }
}
