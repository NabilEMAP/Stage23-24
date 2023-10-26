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
    public class TeamplanningConfiguration : IEntityTypeConfiguration<Teamplanning>
    {
        public void Configure(EntityTypeBuilder<Teamplanning> builder)
        {
            builder.ToTable("Teamplanningen", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Maand)
                    .IsRequired()
                    .HasColumnType("int");

        }
    }
}
