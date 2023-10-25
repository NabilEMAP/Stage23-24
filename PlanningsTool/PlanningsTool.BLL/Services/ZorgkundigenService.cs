using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Zorgkundigen;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class ZorgkundigenService : IZorgkundigenService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public ZorgkundigenService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ZorgkundigeDTO> Add(CreateZorgkundigeDTO entity)
        {
            var zorgkundige = _mapper.Map<Zorgkundige>(entity);
            await _uow.ZorgkundigenRepository.Add(zorgkundige);
            await _uow.Save();
            return _mapper.Map<ZorgkundigeDTO>(zorgkundige);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteZorgkundige = await _uow.ZorgkundigenRepository.GetZorgkundigenAsyncById(id);
            if (toDeleteZorgkundige == null)
            {
                throw new KeyNotFoundException("This zorgkundige does not exist.");
            }
            _uow.ZorgkundigenRepository.Delete(toDeleteZorgkundige);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<ZorgkundigeDTO>> GetAll()
        {
            var zorgkundigen = await _uow.ZorgkundigenRepository.GetAllZorgkundigenAsync();
            return _mapper.Map<IEnumerable<ZorgkundigeDTO>>(zorgkundigen);
        }

        public async Task<ZorgkundigeDTO> GetById(int id)
        {
            var zorgkundige = await _uow.ZorgkundigenRepository.GetZorgkundigenAsyncById(id);
            return _mapper.Map<ZorgkundigeDTO>(zorgkundige);
        }

        public async Task<IEnumerable<ZorgkundigeDTO>> GetZorgkundigenByAchternaam(string achternaam)
        {
            var zorgkundigen = await _uow.ZorgkundigenRepository.GetZorgkundigenByAchternaam(achternaam);
            return _mapper.Map<IEnumerable<ZorgkundigeDTO>>(zorgkundigen);
        }

        public async Task<IEnumerable<ZorgkundigeDTO>> GetZorgkundigenByVoornaam(string voornaam)
        {
            var zorgkundigen = await _uow.ZorgkundigenRepository.GetZorgkundigenByVoornaam(voornaam);
            return _mapper.Map<IEnumerable<ZorgkundigeDTO>>(zorgkundigen);
        }

        public async Task<ZorgkundigeDTO> Update(int id, UpdateZorgkundigeDTO entity)
        {
            var zorgkundigeFromRequest = _mapper.Map<Zorgkundige>(entity);
            var zorgkundigeToUpdate = await _uow.ZorgkundigenRepository.GetZorgkundigenAsyncById(id);

            if (zorgkundigeToUpdate == null)
            {
                throw new KeyNotFoundException("This zorgkundige does not exist.");
            }

            zorgkundigeToUpdate.Voornaam = zorgkundigeFromRequest.Voornaam;
            zorgkundigeToUpdate.Achternaam = zorgkundigeFromRequest.Achternaam;
            zorgkundigeToUpdate.RegimeId = zorgkundigeFromRequest.RegimeId;
            zorgkundigeToUpdate.IsVasteNacht = zorgkundigeFromRequest.IsVasteNacht;

            await _uow.ZorgkundigenRepository.Update(zorgkundigeToUpdate);
            await _uow.Save();
            return _mapper.Map<ZorgkundigeDTO>(zorgkundigeToUpdate);
        }
    }
}
