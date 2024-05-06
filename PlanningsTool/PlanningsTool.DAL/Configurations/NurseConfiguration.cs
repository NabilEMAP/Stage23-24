using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Configurations
{
    public class NurseConfiguration : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.ToTable("Nurses", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.HasOne(p => p.RegimeType)
                    .WithMany()
                    .HasForeignKey(p => p.RegimeTypeId);

            builder.Property(p => p.RegimeTypeId)
                    .IsRequired()
                    //.HasDefaultValue(1)
                    .HasColumnType("int");

            builder.Property(p => p.IsFixedNight)
                    .IsRequired()
                    .HasColumnType("char(1)");

            builder.HasOne(p => p.Team)
                    .WithMany()
                    .HasForeignKey(p => p.TeamId);

            builder.Property(p => p.TeamId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
