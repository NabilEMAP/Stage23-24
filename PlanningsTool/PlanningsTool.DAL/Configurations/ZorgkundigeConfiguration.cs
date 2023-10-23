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
    public class ZorgkundigeConfiguration : IEntityTypeConfiguration<Zorgkundige>
    {
        public void Configure(EntityTypeBuilder<Zorgkundige> builder)
        {
            builder.ToTable("Zorgkundigen", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Voornaam)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.Achternaam)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.HasOne(p => p.RegimeType)
                    .WithMany()
                    .HasForeignKey(p => p.RegimeId);
            // Check on OnDelete() Configurations

            builder.Property(p => p.RegimeId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.Property(p => p.IsVasteNacht)
                    .IsRequired()
                    .HasColumnType("char(1)");
        }
    }
}
