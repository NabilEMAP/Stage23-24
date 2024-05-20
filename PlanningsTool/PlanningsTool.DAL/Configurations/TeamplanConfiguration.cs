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

            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.PlanFor)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.CreatedOn)
                    .IsRequired()
                    .HasColumnType("datetime");



            builder.Property(p => p.TeamId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
