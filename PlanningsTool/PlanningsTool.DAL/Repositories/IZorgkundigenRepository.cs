﻿
using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IZorgkundigenRepository : IGenericRepository<Zorgkundige>
    {
        Task<Zorgkundige> GetZorgkundigeByAchternaam(string achternaam);
        Task<Zorgkundige> GetZorgkundigeByVoornaam(string voornaam);

    }
}