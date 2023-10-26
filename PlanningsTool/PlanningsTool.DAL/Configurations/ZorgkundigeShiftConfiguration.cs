using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Configurations
{
    public class ZorgkundigeShiftConfiguration : IEntityTypeConfiguration<ZorgkundigeShift>
    {
        public void Configure(EntityTypeBuilder<ZorgkundigeShift> builder)
        {
            builder.ToTable("ZorgkundigeShifts", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Datum)
                    .IsRequired()
                    .HasColumnType("date");

            builder.HasOne(p => p.Zorgkundige)
                    .WithMany()
                    .HasForeignKey(p => p.ZorgkundigeId);

            builder.Property(p => p.ZorgkundigeId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.Shift)
                    .WithMany()
                    .HasForeignKey(p => p.ShiftId);

            builder.Property(p => p.ShiftId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.Teamplanning)
                    .WithMany()
                    .HasForeignKey(p => p.TeamplanningId);

            builder.Property(p => p.TeamplanningId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
