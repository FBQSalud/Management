using AutoMapper;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Application.Services
{
    public interface IComunicacionesServices
    {
        List<Comunicaciones> GetAll();
        Comunicaciones GetComunicacionById(int id);
        void Update(Comunicaciones comunicacion);
        void Delete(Comunicaciones comunicacion);
        void Add(Comunicaciones comunicacion);
        Comunicaciones CreateComunicacion(ComunicacionesDto comunicacion);
    }
    public class ComunicacionesServices : IComunicacionesServices
    {
        private readonly IMapper _mapper;
        private readonly IComunicacionesRepository _comunicacionesRepository;

        public ComunicacionesServices(IMapper mapper, IComunicacionesRepository comunicacionesRepository)
        {
            _mapper = mapper;
            _comunicacionesRepository = comunicacionesRepository;
        }

        public List<Comunicaciones> GetAll()
        {
            return _comunicacionesRepository.GetAll();
        }

        public Comunicaciones GetComunicacionById(int id)
        {
            return _comunicacionesRepository.GetComunicacionById(id);
        }

        public Comunicaciones CreateComunicacion(ComunicacionesDto comunicacion)
        {
            var comunicacionMapped = _mapper.Map<Comunicaciones>(comunicacion);
            _comunicacionesRepository.Add(comunicacionMapped);
            return comunicacionMapped;
        }

        public void Add(Comunicaciones comunicacion)
        {
            var comunicacionMapped = _mapper.Map<Comunicaciones>(comunicacion);
            _comunicacionesRepository.Add(comunicacionMapped);
        }

        public void Update(Comunicaciones comunicacion)
        {
            _comunicacionesRepository.Update(comunicacion);
        }

        public void Delete(Comunicaciones comunicacion)
        {
            _comunicacionesRepository.Delete(comunicacion);
        }           
    }
}
