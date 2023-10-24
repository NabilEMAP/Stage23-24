using PlanningsTool.Common.DTO.VerlofTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IVerlofTypesService
    {
        public Task<IEnumerable<VerlofTypeDTO>> GetAll();
        public Task<VerlofTypeDTO> GetById(int id);
        public Task<IEnumerable<VerlofTypeDTO>> GetVerlofTypesByNaam(string naam);
    }
}
