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
    public class VerlofTypeConfiguration : IEntityTypeConfiguration<VerlofType>
    {
        public void Configure(EntityTypeBuilder<VerlofType> builder)
        {
            builder.ToTable("VerlofTypes", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Verlof)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
        }
    }
}
