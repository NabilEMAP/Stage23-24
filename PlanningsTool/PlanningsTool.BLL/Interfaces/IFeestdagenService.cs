using PlanningsTool.Common.DTO.Feestdagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IFeestdagenService
    {
        public Task<IEnumerable<FeestdagDTO>> GetAll();
        public Task<FeestdagDTO> GetById(int id);
        public Task<IEnumerable<FeestdagDTO>> GetFeestdagenByNaam(string naam);
        public Task<IEnumerable<FeestdagDTO>> GetFeestdagenByDatum(string datum);
        public Task<int> Add(int jaar);
        public Task<int> ClearAll();
        public Task<bool> CheckIfExist(int jaar);
    }
}
