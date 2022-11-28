using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly IInsumosService _service;
        private readonly IMapper _mapper;

        public InsumosController(IInsumosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var insumo = _service.GetAll();
                var insumoMapped = _mapper.Map<List<InsumosGetDto>>(insumo);

                return Ok(insumoMapped);
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
                var insumo = _service.GetInsumoById(id);
                var insumoMapped = _mapper.Map<InsumosGetDto>(insumo);
                if (insumo == null)
                {
                    return NotFound("Insumo Inexistente");
                }
                return Ok(insumoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateInsumo([FromBody] InsumosDto insumo)
        {
            try
            {
                var insumoEntity = _service.CreateInsumo(insumo);

                if (insumoEntity != null)
                {
                    var insumoCreated = _mapper.Map<InsumosDto>(insumoEntity);
                    return Ok("Insumo Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInsumo(int id, InsumosDto insumo)
        {
            try
            {
                if (insumo == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var insumoUpdate = _service.GetInsumoById(id);

                if (insumoUpdate == null)
                {
                    return NotFound("Insumo Inexistente");
                }

                _mapper.Map(insumo, insumoUpdate);
                _service.Update(insumoUpdate);

                return Ok("Insumo actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInsumo(int id)
        {
            try
            {
                var insumo = _service.GetInsumoById(id);

                if (insumo == null)
                {
                    return NotFound("Insumo Inexistente");
                }

                _service.Delete(insumo);
                return Ok("Insumo eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
