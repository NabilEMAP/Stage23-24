using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Configurations
{
    public class TeamplanConfiguration : IEntityTypeConfiguration<Teamplan>
    {
        public void Configure(EntityTypeBuilder<Teamplan> builder)
        {
            builder.ToTable("Teamplans", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Month)
                    .IsRequired()
                    .HasColumnType("int");

        }
    }
}
