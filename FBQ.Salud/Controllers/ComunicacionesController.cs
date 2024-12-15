using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunicacionesController : ControllerBase
    {
        private readonly IComunicacionesServices _service;
        private readonly IMapper _mapper;

        public ComunicacionesController(IComunicacionesServices service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var comunicaciones = _service.GetAll();
                var comunicacionesoMapped = _mapper.Map<List<ComunicacionesDto>>(comunicaciones);

                return Ok(comunicaciones);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Createcomunicacion([FromBody] ComunicacionesDto comunicacion)
        {
            try
            {
                var comunicacionEntity = _service.CreateComunicacion(comunicacion);

                if (comunicacionEntity != null)
                {
                    var insumoCreated = _mapper.Map<ComunicacionesDto>(comunicacionEntity);
                    return Ok("Comunicacion Creada");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetComunicacion(int id)
        {
            try
            {
                var comunicacion = _service.GetComunicacionById(id);

                if (comunicacion == null)
                {
                    return NotFound("Comunicación no encontrada");
                }

                return Ok(comunicacion); // Devuelve los datos en formato JSON
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComunicacion(int id, [FromBody] ComunicacionesDto comunicacion)
        {
            try
            {
                var existingComunicacion = _service.GetComunicacionById(id);
                if (existingComunicacion == null)
                    return NotFound("Comunicación no encontrada.");

                // Actualizar campos necesarios
                existingComunicacion.ComunicacionName = comunicacion.ComunicacionName;
                existingComunicacion.FechaComunicacion = comunicacion.FechaComunicacion;

                _service.Update(existingComunicacion);
                return Ok("Comunicación actualizada correctamente.");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al actualizar la comunicación: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComunicacion(int id)
        {
            try
            {
                var comunicacion = _service.GetComunicacionById(id);

                if (comunicacion == null)
                {
                    return NotFound("Comunicacion Inexistente");
                }

                _service.Delete(comunicacion);
                return Ok("Comunicacion eliminada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
