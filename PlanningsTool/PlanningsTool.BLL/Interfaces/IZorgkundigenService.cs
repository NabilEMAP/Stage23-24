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
        public Task<IEnumerable<ZorgkundigeDetailDTO>> GetAllDetails();
        public Task<ZorgkundigeDetailDTO> GetById(int id);
        public Task<IEnumerable<ZorgkundigeDetailDTO>> GetZorgkundigenByVoornaam(string voornaam);
        public Task<IEnumerable<ZorgkundigeDetailDTO>> GetZorgkundigenByAchternaam(string achternaam);
        public Task<ZorgkundigeDetailDTO> Add(CreateZorgkundigeDTO zorgkundige);
        public Task<ZorgkundigeDetailDTO> Update(int id, UpdateZorgkundigeDTO zorgkundige);
        public Task<int> Delete(int id);
    }
}
