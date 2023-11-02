using AutoMapper;
using FluentValidation.Results;
using PlanningsTool.BLL.Exceptions;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.BLL.Validations;
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
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CreateZorgkundigeValidator _createValidator;

        public ZorgkundigenService(IUnitOfWork uow, IMapper mapper, CreateZorgkundigeValidator createValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<ZorgkundigeDTO> Add(CreateZorgkundigeDTO entity)
        {
            ValidationResult validationResult = _createValidator.Validate(entity);

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var zorgkundige = _mapper.Map<Zorgkundige>(entity);
            await _uow.ZorgkundigenRepository.Add(zorgkundige);
            await _uow.Save();
            return _mapper.Map<ZorgkundigeDTO>(zorgkundige);
        }

        public async Task<int> Delete(int id)
        {
            var toDeleteZorgkundige = await _uow.ZorgkundigenRepository.GetZorgkundigeAsyncById(id);
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
            var zorgkundige = await _uow.ZorgkundigenRepository.GetZorgkundigeAsyncById(id);
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
            var zorgkundigeToUpdate = await _uow.ZorgkundigenRepository.GetZorgkundigeAsyncById(id);

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
