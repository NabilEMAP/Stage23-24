using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IVerlofTypesRepository : IGenericRepository<VerlofType>
    {
        Task<IEnumerable<VerlofType>> GetVerlofTypesByNaam(string naam);
    }
}
