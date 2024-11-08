﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanningsTool.DAL.Models;

namespace PlanningsTool.DAL.Seeding
{
    public static class TeamplanSeeding
    {
        public static void Seed(this EntityTypeBuilder<Teamplan> modelBuilder)
        {
            modelBuilder.HasData(
                new Teamplan() { Id = 1, Name = "2024-05-16-00-07-19 W&L", PlanFor = new DateTime(2022, 03, 01), CreatedOn = new DateTime(2024, 05, 15, 22, 07, 19), TeamId = 1 },
                new Teamplan() { Id = 2, Name = "2024-05-16-13-51-19 TeamRed", PlanFor = new DateTime(2024, 05, 01), CreatedOn = new DateTime(2024, 05, 16, 11, 51, 59), TeamId = 2 },
                new Teamplan() { Id = 3, Name = "2024-05-16-13-52-19 TeamBlue", PlanFor = new DateTime(2024, 05, 01), CreatedOn = new DateTime(2024, 05, 16, 11, 52, 14), TeamId = 3 }
            );
        }
    }
}
