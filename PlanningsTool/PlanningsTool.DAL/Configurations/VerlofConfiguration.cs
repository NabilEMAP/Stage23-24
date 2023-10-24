using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Configurations
{
    public class VerlofConfiguration : IEntityTypeConfiguration<Verlof>
    {
        public void Configure(EntityTypeBuilder<Verlof> builder)
        {
            builder.ToTable("Verloven", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Startdatum)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.Einddatum)
                    .IsRequired()
                    .HasColumnType("date");

            builder.Property(p => p.Reden)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

            builder.HasOne(p => p.Zorgkundige)
                    .WithMany()
                    .HasForeignKey(p => p.ZorgkundigeId);

            builder.Property(p => p.ZorgkundigeId)
                    .IsRequired()
                    .HasColumnType("int");

            builder.HasOne(p => p.VerlofType)
                    .WithMany()
                    .HasForeignKey(p => p.VerlofTypeId);

            builder.Property(p => p.VerlofTypeId)
                    .IsRequired()
                    .HasColumnType("int");
        }
    }
}
