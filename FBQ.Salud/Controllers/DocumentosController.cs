using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.SaludPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly IDocumentosSevice _service;
        private readonly IMapper _mapper;

        public DocumentosController(IDocumentosSevice service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var documento = _service.GetAll();
                var documentoMapped = _mapper.Map<List<DocumentosDto>>(documento);

                return Ok(documentoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var documento = _service.GetDocumentoById(id);
                var documentoMapped = _mapper.Map<DocumentosDto>(documento);
                if (documento == null)
                {
                    return NotFound("Documento Inexistente");
                }
                return Ok(documentoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePaciente([FromForm] DocumentosDto documento)
        {
            try
            {
                var documentoEntity = _service.CreateDocumento(documento);

                if (documentoEntity != null)
                {
                    var pacienteCreated = _mapper.Map<DocumentosDto>(documentoEntity);
                    return Ok("Documento Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDocumento(int id, DocumentosDto documento)
        {
            try
            {
                if (documento == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var documentoUpdate = _service.GetDocumentoById(id);

                if (documentoUpdate == null)
                {
                    return NotFound("Documento Inexistente");
                }

                _mapper.Map(documento, documentoUpdate);
                _service.Update(documentoUpdate);

                return Ok("Documento actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocumento(int id)
        {
            try
            {
                var documento = _service.GetDocumentoById(id);

                if (documento == null)
                {
                    return NotFound("Documento Inexistente");
                }

                _service.Delete(documento);
                return Ok("Documento eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
