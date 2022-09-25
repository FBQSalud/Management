using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class DocumentosRepository : IDocumentosRepository
    {
        private readonly FBQSaludDbContext _context;

        public DocumentosRepository(FBQSaludDbContext context)
        {
            _context = context;
        }
        public void Add(Documentos documento)
        {
            _context.Documentos.Add(documento);
            _context.SaveChanges();
        }

        public void Delete(Documentos documento)
        {
            _context.Documentos.Remove(documento);
            _context.SaveChanges();
        }

        public List<Documentos> GetAll()
        {
            return _context.Documentos.ToList();
        }

        public Documentos GetDocumentoById(int id)
        {
            return _context.Documentos.FirstOrDefault(x => x.DocumentoId == id);
        }

        public void Update(Documentos documento)
        {
            _context.Documentos.Update(documento);
            _context.SaveChanges();
        }
    }
}
