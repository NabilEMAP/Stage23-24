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
    public class FeestdagConfiguration : IEntityTypeConfiguration<Feestdag>
    {
        public void Configure(EntityTypeBuilder<Feestdag> builder)
        {
            builder.ToTable("Feestdagen", "dbo")
                    .HasKey(p => p.Id);
            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Id)
                   .HasColumnType("int");

            builder.Property(p => p.Naam)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.Datum)
                    .IsRequired()
                    .HasColumnType("date");
        }
    }
}
