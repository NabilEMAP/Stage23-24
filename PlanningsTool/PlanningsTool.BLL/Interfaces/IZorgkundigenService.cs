using PlanningsTool.Common.DTO.Zorgkundigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Interfaces
{
    public interface IZorgkundigenService
    {
        public Task<IEnumerable<ZorgkundigeDTO>> GetAll();
        public Task<ZorgkundigeDTO> GetById(int id);
        public Task<IEnumerable<ZorgkundigeDTO>> GetZorgkundigenByVoornaam(string voornaam);
        public Task<IEnumerable<ZorgkundigeDTO>> GetZorgkundigenByAchternaam(string achternaam);
        public Task<ZorgkundigeDTO> Add(CreateZorgkundigeDTO zorgkundige);
        public Task<ZorgkundigeDTO> Update(int id, UpdateZorgkundigeDTO zorgkundige);
        public Task<int> Delete(int id);
    }
}
