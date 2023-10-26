using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Configurations;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Zorgkundige> Zorgkundigen { get; set; }
        public virtual DbSet<RegimeType> RegimeTypes { get; set; }
        public virtual DbSet<VerlofType> VerlofTypes { get; set; }
        public virtual DbSet<ShiftType> ShiftTypes { get; set; }
        public virtual DbSet<Verlof> Verloven { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ZorgkundigeShift> ZorgkundigeShifts { get; set; }
        public virtual DbSet<Teamplanning> Teamplanningen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ZorgkundigeConfiguration());
            modelBuilder.ApplyConfiguration(new RegimeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VerlofTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VerlofConfiguration());
            modelBuilder.ApplyConfiguration(new ShiftConfiguration());
            modelBuilder.ApplyConfiguration(new ZorgkundigeShiftConfiguration());
            modelBuilder.ApplyConfiguration(new TeamplanningConfiguration());
            modelBuilder.Entity<Zorgkundige>().Seed();
            modelBuilder.Entity<RegimeType>().Seed();
            modelBuilder.Entity<VerlofType>().Seed();
            modelBuilder.Entity<ShiftType>().Seed();
            modelBuilder.Entity<Verlof>().Seed();
            modelBuilder.Entity<Shift>().Seed();
            modelBuilder.Entity<ZorgkundigeShift>().Seed();
            modelBuilder.Entity<Teamplanning>().Seed();
        }
    }
}
