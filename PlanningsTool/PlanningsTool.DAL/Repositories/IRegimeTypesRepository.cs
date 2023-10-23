using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IRegimeTypesRepository : IGenericRepository<RegimeType>
    {
        Task<IEnumerable<RegimeType>> GetRegimeTypesByNaam(string naam);
        Task<IEnumerable<RegimeType>> GetRegimeTypesByAantalUren(string aantalUren);

    }
}
