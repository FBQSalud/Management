using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class IsumosRepository : IInsumosRepository
    {
        private readonly FBQSaludDbContext _context;

        public IsumosRepository(FBQSaludDbContext context)
        {
            _context= context;
        }
        public void Add(Insumos insumo)
        {
            _context.Insumos.Add(insumo);
            _context.SaveChanges();
        }

        public void Delete(Insumos insumo)
        {
            _context.Insumos.Remove(insumo);
            _context.SaveChanges();
        }

        public List<Insumos> GetAll()
        {
            return _context.Insumos.ToList();
        }

        public Insumos GetInsumoById(int id)
        {
            return _context.Insumos.FirstOrDefault(x => x.InsumosId == id);
        }

        public void Update(Insumos insumo)
        {
            _context.Insumos.Update(insumo);
            _context.SaveChanges();
        }
    }
}
