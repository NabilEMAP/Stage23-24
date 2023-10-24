using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Seeding
{
    public static class VerlofTypeSeeding
    {
        public static void Seed(this EntityTypeBuilder<VerlofType> modelBuilder)
        {
            modelBuilder.HasData(
                new VerlofType()
                {
                    Id = 1,
                    Verlof = "Verlof",
                },
                new VerlofType()
                {
                    Id = 2,
                    Verlof = "Ziekte",
                },
                new VerlofType()
                {
                    Id = 3,
                    Verlof = "Arbeidsduurverkorting",
                },
                new VerlofType()
                {
                    Id = 4,
                    Verlof = "Wens",
                },
                new VerlofType()
                {
                    Id = 5,
                    Verlof = "Andere",
                }
            );
        }
    }
}
