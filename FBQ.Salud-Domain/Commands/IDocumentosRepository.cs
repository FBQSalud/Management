using FBQ.Salud_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Commands
{
    public interface IDocumentosRepository
    {
        List<Documentos> GetAll();
        Documentos GetDocumentoById(int id);
        void Update(Documentos documento);
        void Delete(Documentos documento);
        void Add(Documentos documento);
    }
}
