using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.Property(p => p.Regime)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.AantalUren)
                    .IsRequired()
                    .HasColumnType("decimal(3,1)");
        }
    }
}
