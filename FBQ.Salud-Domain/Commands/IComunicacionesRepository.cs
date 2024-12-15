
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IComunicacionesRepository
    {
        List<Comunicaciones> GetAll();
        Comunicaciones GetComunicacionById(int id);
        void Update(Comunicaciones comunicacion);
        void Delete(Comunicaciones comunicacion);
        void Add(Comunicaciones comunicacion);
    }
}
