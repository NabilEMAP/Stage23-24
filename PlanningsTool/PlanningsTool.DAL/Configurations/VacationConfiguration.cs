using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Configurations
{
    public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable("Vacations", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Startdate)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.Enddate)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.Reason)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

            builder.HasOne(p => p.Nurse)
                    .WithMany()
                    .HasForeignKey(p => p.NurseId);

            builder.Property(p => p.NurseId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.VacationType)
                    .WithMany()
                    .HasForeignKey(p => p.VacationTypeId);

            builder.Property(p => p.VacationTypeId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
