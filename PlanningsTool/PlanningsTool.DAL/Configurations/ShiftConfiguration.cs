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
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("Shifts", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Starttijd)
                    .IsRequired()
                    .HasColumnType("time");

            builder.Property(p => p.Eindtijd)
                    .IsRequired()
                    .HasColumnType("time");

            builder.HasOne(p => p.ShiftType)
                    .WithMany()
                    .HasForeignKey(p => p.ShiftTypeId);

            builder.Property(p => p.ShiftTypeId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
