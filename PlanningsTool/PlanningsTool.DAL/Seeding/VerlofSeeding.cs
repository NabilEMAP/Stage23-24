using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class VerlofSeeding
    {
        public static void Seed(this EntityTypeBuilder<Verlof> modelBuilder)
        {
            modelBuilder.HasData(
                new Verlof()
                {
                    Id = 1,
                    Startdatum = new DateTime(2023, 9, 15),
                    Einddatum = new DateTime(2023, 9, 15),
                    Reden = "Verlofdagje op vrijdag.",
                    ZorgkundigeId = 1,
                    VerlofTypeId = 1
                },
                new Verlof()
                {
                    Id = 2,
                    Startdatum = new DateTime(2023, 9, 18),
                    Einddatum = new DateTime(2023, 9, 24),
                    Reden = "Heel de week ziek geweest.",
                    ZorgkundigeId = 2,
                    VerlofTypeId = 2
                }
            );
        }
    }
}
