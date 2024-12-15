using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IInsumosRepository
    {
        List<Insumos> GetAll();
        Insumos GetInsumoById(int id);
        void Update(Insumos insumo);
        void Delete(Insumos insumo);
        void Add(Insumos insumo);
    }
}
