using PlanningsTool.Common.DTO.RegimeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IRegimeTypesService
    {
        public Task<IEnumerable<RegimeTypeDTO>> GetAll();
        public Task<RegimeTypeDTO> GetById(int id);
        public Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByNaam(string naam);
        public Task<IEnumerable<RegimeTypeDTO>> GetRegimeTypesByAantalUren(string aantalUren);
    }
}
