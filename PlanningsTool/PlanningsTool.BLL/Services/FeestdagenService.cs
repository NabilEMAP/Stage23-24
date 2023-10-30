using AutoMapper;
using PlanningsTool.BLL.Interfaces;
using PlanningsTool.Common.DTO.Feestdagen;
using PlanningsTool.DAL.Models;
using PlanningsTool.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Services
{
    public class FeestdagenService : IFeestdagenService
    {
        public readonly IUnitOfWork _uow;
        public readonly IMapper _mapper;

        public FeestdagenService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Add(int jaar)
        {
            await _uow.FeestdagenRepository.AddFeestdagenByYear(jaar);
            await _uow.Save();
            return _mapper.Map<int>(jaar);
        }

        public async Task<bool> CheckIfExist(int jaar)
        {
            string jaarToString = jaar.ToString();
            var feestdagen = await _uow.FeestdagenRepository.GetFeestdagenByDatum(jaarToString);
            return feestdagen.Any();
        }

        public async Task<int> ClearAll()
        {
            foreach (var item in await _uow.FeestdagenRepository.GetAllAsync())
            {
                _uow.FeestdagenRepository.Delete(item);
            }
            await _uow.Save();
            return 0;
        }

        public async Task<IEnumerable<FeestdagDTO>> GetAll()
        {
            var feestdagen = await _uow.FeestdagenRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeestdagDTO>>(feestdagen);
        }

        public async Task<FeestdagDTO> GetById(int id)
        {
            var feestdag = await _uow.FeestdagenRepository.GetByIdAsync(id);
            return _mapper.Map<FeestdagDTO>(feestdag);
        }

        public async Task<IEnumerable<FeestdagDTO>> GetFeestdagenByDatum(string datum)
        {
            var feestdagen = await _uow.FeestdagenRepository.GetFeestdagenByDatum(datum);
            return _mapper.Map<IEnumerable<FeestdagDTO>>(feestdagen);
        }

        public async Task<IEnumerable<FeestdagDTO>> GetFeestdagenByNaam(string naam)
        {
            var feestdagen = await _uow.FeestdagenRepository.GetFeestdagenByNaam(naam);
            return _mapper.Map<IEnumerable<FeestdagDTO>>(feestdagen);
        }
    }
}
