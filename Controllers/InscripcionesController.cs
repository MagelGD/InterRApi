using Api.Data.Models;
using Api.Services.Interfaces.InscripcionesSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly IInscripcionesSer _inscripcionesSer;
        private readonly ILogger _logger;

        public InscripcionesController(IInscripcionesSer inscripcionesSer, ILogger<InscripcionesController> logger)
        {
            _inscripcionesSer = inscripcionesSer;
            _logger = logger;
        }
        /// <summary>
        /// Metodo para listar las inscripciones
        /// </summary>
        /// <returns>Devuelve una lista de las inscripciones</returns>
        // GET: api/<InscripcionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripciones>>> Get()
        {
            try
            {
                return Ok(await _inscripcionesSer.ListInscripciones(null));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para seleccionar una inscripcion especifica
        /// </summary>
        /// <param name="id">id de la inscripcion especifica</param>
        /// <returns>Devuelve el modelo de la inscripcion especifica</returns>
        // GET api/<InscripcionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripciones>> Get(int id)
        {
            try
            {
                return Ok(await _inscripcionesSer.SeleccionarInscripcionesId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para actualizar o agregar un nuevo modelo de inscripcion
        /// </summary>
        /// <param name="value">Modelo para actualizar o agregar</param>
        /// <returns>Devuelve el modelo el cual actualizo o agrego</returns>
        // POST api/<InscripcionesController>
        [HttpPost]
        public async Task<ActionResult<Inscripciones>> Post([FromBody] Inscripciones value)
        {
            try
            {
                return Ok(await _inscripcionesSer.MergeInscripciones(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Post)}");
            }
            return BadRequest();
        }

        //// PUT api/<InscripcionesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InscripcionesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
