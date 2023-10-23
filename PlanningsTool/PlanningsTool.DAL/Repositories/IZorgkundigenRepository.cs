
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
        Task<IEnumerable<Zorgkundige>> GetAllZorgkundigenAsync();
        Task<IEnumerable<Zorgkundige>> GetZorgkundigenByAchternaam(string achternaam);
        Task<IEnumerable<Zorgkundige>> GetZorgkundigenByVoornaam(string voornaam);

    }
}
