using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Configurations
{
    public class NurseShiftConfiguration : IEntityTypeConfiguration<NurseShift>
    {
        public void Configure(EntityTypeBuilder<NurseShift> builder)
        {
            builder.ToTable("NurseShifts", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Date)
                    .IsRequired()
                    .HasColumnType("date");

            builder.HasOne(p => p.Nurse)
                    .WithMany()
                    .HasForeignKey(p => p.NurseId);

            builder.Property(p => p.NurseId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.Shift)
                    .WithMany()
                    .HasForeignKey(p => p.ShiftId);

            builder.Property(p => p.ShiftId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.Teamplan)
                    .WithMany()
                    .HasForeignKey(p => p.TeamplanId);

            builder.Property(p => p.TeamplanId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
