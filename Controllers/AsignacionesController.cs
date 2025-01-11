using Api.Data.Models;
using Api.Services.Interfaces.AsigncacionesSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly IAsignacionesSer _signacionesSer;
        private readonly ILogger _logger;

        public AsignacionesController(IAsignacionesSer asignacionesSer, ILogger<AsignacionesController> logger)
        {
            _logger = logger;
            _signacionesSer = asignacionesSer;
        }

        /// <summary>
        /// Metodo para listar las asignaciones
        /// </summary>
        /// <returns>Devuelve una lista</returns>
        // GET: api/<AsignacionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignaciones>>> Get()
        {
            try
            {
                return Ok(await _signacionesSer.ListAsignaciones(null));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }
        /// <summary>
        /// Metodo para seleccionar una asignacion especifica
        /// </summary>
        /// <param name="id">id de la asignacion</param>
        /// <returns>Devuelve el modelo de la seleccion especifica </returns>
        // GET api/<AsignacionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignaciones>> Get(int id)
        {
            try
            {
                return Ok(await _signacionesSer.SeleccionarAsignacionesId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para actualizar o agregar un registro nuevo
        /// </summary>
        /// <param name="value">modelo para actualizar o agregar</param>
        /// <returns>Devuelve el modelo actualizado o agregado</returns>
        // POST api/<AsignacionesController>
        [HttpPost]
        public async Task<ActionResult<Asignaciones>> Post([FromBody] Asignaciones value)
        {
            try
            {
                return Ok(await _signacionesSer.MergeAsignaciones(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Post)}");
            }
            return BadRequest();
        }

        //// PUT api/<AsignacionesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AsignacionesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
