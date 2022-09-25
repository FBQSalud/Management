using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Application.Services
{
    public interface IInsumosService
    {
        List<Insumos> GetAll();
        Insumos GetInsumoById(int id);
        void Update(Insumos insumo);
        void Delete(Insumos insumo);
        void Add(Insumos insumo);
        Insumos CreateInsumo(InsumosDto insumo);
    }
    public class InsumosServices : IInsumosService
    {
        private readonly IMapper _mapper;
        private readonly IInsumosRepository _insumosRepository;

        public InsumosServices(IMapper mapper, IInsumosRepository insumosRepository)
        {
            _mapper = mapper;
            _insumosRepository = insumosRepository;
        }
        public void Add(Insumos insumo)
        {
            var insumoMapped = _mapper.Map<Insumos>(insumo);
            _insumosRepository.Add(insumoMapped);
        }

        public Insumos CreateInsumo(InsumosDto insumo)
        {
            var insumoMapped = _mapper.Map<Insumos>(insumo);
            _insumosRepository.Add(insumoMapped);
            return insumoMapped;
        }

        public void Delete(Insumos insumo)
        {
            _insumosRepository.Delete(insumo);
        }

        public List<Insumos> GetAll()
        {
            return _insumosRepository.GetAll();
        }

        public Insumos GetInsumoById(int id)
        {
            return _insumosRepository.GetInsumoById(id);
        }

        public void Update(Insumos insumo)
        {
            _insumosRepository.Update(insumo);
        }
    }
}
