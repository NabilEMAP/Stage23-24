using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IVerlovenRepository : IGenericRepository<Verlof>
    {
        Task<IEnumerable<Verlof>> GetAllVerlovenAsync();
        Task<IEnumerable<Verlof>> GetVerlovenByStartdatum(string startdatum);
        Task<IEnumerable<Verlof>> GetVerlovenByEinddatum(string einddatum);
        Task<IEnumerable<Verlof>> GetVerlovenByReden(string reden);
    }
}
