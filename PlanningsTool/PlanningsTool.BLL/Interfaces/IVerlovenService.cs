using PlanningsTool.Common.DTO.Verloven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IVerlovenService
    {
        public Task<IEnumerable<VerlofDTO>> GetAll();
        public Task<IEnumerable<VerlofDetailDTO>> GetAllDetails();
        public Task<VerlofDetailDTO> GetById(int id);
        public Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByStartdatum(string startdatum);
        public Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByEinddatum(string einddatum);
        public Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByReden(string reden);
        public Task<VerlofDetailDTO> Add(CreateVerlofDTO verlof);
        public Task<VerlofDetailDTO> Update(int id, UpdateVerlofDTO verlof);
        public Task<int> Delete(int id);
    }
}
