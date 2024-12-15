
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class ComunicacionesRepository : IComunicacionesRepository
    {
        private readonly FBQSaludDbContext _context;

        public ComunicacionesRepository(FBQSaludDbContext context)
        {
            _context = context;
        }

        public List<Comunicaciones> GetAll()
        {
            return _context.Comunicaciones .ToList();
        }

        public Comunicaciones GetComunicacionById(int id)
        {
            return _context.Comunicaciones.FirstOrDefault(x => x.ComunicacionesId == id);
        }

        public void Update(Comunicaciones comunicacion)
        {
            _context.Comunicaciones.Update(comunicacion);
            _context.SaveChanges();
        }

        public void Add(Comunicaciones comunicacion)
        {
            _context.Comunicaciones.Add(comunicacion);
            _context.SaveChanges();
        }

        public void Delete(Comunicaciones comunicacion)
        {
            _context.Comunicaciones.Remove(comunicacion);
            _context.SaveChanges();
        }     
    }
}
