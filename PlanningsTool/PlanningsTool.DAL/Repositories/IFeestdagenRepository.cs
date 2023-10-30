using PlanningsTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Repositories
{
    public interface IFeestdagenRepository : IGenericRepository<Feestdag>
    {
        Task AddFeestdagenByYear(int year);
        Task<IEnumerable<Feestdag>> GetFeestdagenByNaam(string naam);
        Task<IEnumerable<Feestdag>> GetFeestdagenByDatum(string datum);
    }
}
