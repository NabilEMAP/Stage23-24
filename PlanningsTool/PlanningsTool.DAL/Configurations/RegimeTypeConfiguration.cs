using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Configurations
{
    public class RegimeTypeConfiguration : IEntityTypeConfiguration<RegimeType>
    {
        public void Configure(EntityTypeBuilder<RegimeType> builder)
        {
            builder.ToTable("RegimeTypes", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.CountHours)
                    .IsRequired()
                    .HasColumnType("decimal(3,1)");
        }
    }
}
