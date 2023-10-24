using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Verloven;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class VerlovenService : IVerlovenService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public VerlovenService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<VerlofDetailDTO> Add(CreateVerlofDTO entity)
        {
            var verlof = _mapper.Map<Verlof>(entity);
            await _uow.VerlovenRepository.Add(verlof);
            await _uow.Save();
            return _mapper.Map<VerlofDetailDTO>(verlof);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteVerlof = await _uow.VerlovenRepository.GetByIdAsync(id);
            if (toDeleteVerlof == null)
            {
                throw new KeyNotFoundException("This verlof does not exist.");
            }
            _uow.VerlovenRepository.Delete(toDeleteVerlof);
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<VerlofDTO>> GetAll()
        {
            var verloven = await _uow.VerlovenRepository.GetAllVerlovenAsync();
            return _mapper.Map<IEnumerable<VerlofDTO>>(verloven);
        }

        public async Task<IEnumerable<VerlofDetailDTO>> GetAllDetails()
        {
            var verloven = await _uow.VerlovenRepository.GetAllVerlovenAsync();
            return _mapper.Map<IEnumerable<VerlofDetailDTO>>(verloven);
        }

        public async Task<VerlofDetailDTO> GetById(int id)
        {
            var verlof = await _uow.VerlovenRepository.GetByIdAsync(id);
            return _mapper.Map<VerlofDetailDTO>(verlof);
        }

        public async Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByStartdatum(string startdatum)
        {
            var verloven = await _uow.VerlovenRepository.GetVerlovenByStartdatum(startdatum);
            return _mapper.Map<IEnumerable<VerlofDetailDTO>>(verloven);
        }

        public async Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByEinddatum(string einddatum)
        {
            var verloven = await _uow.VerlovenRepository.GetVerlovenByEinddatum(einddatum);
            return _mapper.Map<IEnumerable<VerlofDetailDTO>>(verloven);
        }

        public async Task<IEnumerable<VerlofDetailDTO>> GetVerlovenByReden(string reden)
        {
            var verloven = await _uow.VerlovenRepository.GetVerlovenByReden(reden);
            return _mapper.Map<IEnumerable<VerlofDetailDTO>>(verloven);
        }

        public async Task<VerlofDetailDTO> Update(int id, UpdateVerlofDTO entity)
        {
            var verlofFromRequest = _mapper.Map<Verlof>(entity);
            var verlofToUpdate = await _uow.VerlovenRepository.GetByIdAsync(id);

            if (verlofToUpdate == null)
            {
                throw new KeyNotFoundException("This verlof does not exist.");
            }

            verlofToUpdate.Startdatum = verlofFromRequest.Startdatum;
            verlofToUpdate.Einddatum = verlofFromRequest.Einddatum;
            verlofToUpdate.Reden = verlofFromRequest.Reden;
            verlofToUpdate.ZorgkundigeId = verlofFromRequest.ZorgkundigeId;
            verlofToUpdate.VerlofTypeId = verlofFromRequest.VerlofTypeId;

            await _uow.VerlovenRepository.Update(verlofToUpdate);
            await _uow.Save();
            return _mapper.Map<VerlofDetailDTO>(verlofToUpdate);
        }
    }
}
