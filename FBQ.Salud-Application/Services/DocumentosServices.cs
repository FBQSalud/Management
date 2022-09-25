using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Application.Services
{
    public interface IDocumentosSevice
    {
        List<Documentos> GetAll();
        Documentos GetDocumentoById(int id);
        void Update(Documentos documento);
        void Delete(Documentos documento);
        void Add(Documentos documento);
        Documentos CreateDocumento(DocumentosDto documento);
    }
    public class DocumentosServices : IDocumentosSevice
    {
        private readonly IMapper _mapper;
        private readonly IDocumentosRepository _documentosRepository;

        public DocumentosServices(IMapper mapper, IDocumentosRepository documentosRepository)
        {
            _mapper = mapper;
            _documentosRepository = documentosRepository;
        }
        public void Add(Documentos documento)
        {
            var documentoMapped=_mapper.Map<Documentos>(documento);
            _documentosRepository.Add(documentoMapped);
        }

        public Documentos CreateDocumento(DocumentosDto documento)
        {
            var documentoMapped = _mapper.Map<Documentos>(documento);
            _documentosRepository.Add(documentoMapped);
            return documentoMapped;
        }

        public void Delete(Documentos documento)
        {
            _documentosRepository.Delete(documento);
        }

        public List<Documentos> GetAll()
        {
            return _documentosRepository.GetAll();
        }

        public Documentos GetDocumentoById(int id)
        {
            return _documentosRepository.GetDocumentoById(id);
        }

        public void Update(Documentos documento)
        {
            _documentosRepository.Update(documento);
        }
    }
}
