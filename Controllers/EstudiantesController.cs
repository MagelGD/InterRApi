using Api.Data.Models;
using Api.Services.Interfaces.EstudiantesSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesSer _estudiantesSer;
        private readonly ILogger _logger;

        public EstudiantesController(IEstudiantesSer estudiantesSer, ILogger<EstudiantesController> logger)
        {
            _estudiantesSer = estudiantesSer;
            _logger = logger;
        }
        /// <summary>
        /// Metodo para seleccionar todos los estudiantes
        /// </summary>
        /// <returns>List Estudiantes</returns>
        // GET: api/<EstudiantesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiantes>>> Get()
        {
            try
            {
                return Ok(await _estudiantesSer.ListEstudiantes(null));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para Selecionar un estudiante Especifico
        /// </summary>
        /// <param name="id">Id Estudiante</param>
        /// <returns>Un Estudiante especifico</returns>
        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiantes>> Get(int id)
        {
            try
            {
                return Ok(await _estudiantesSer.SeleccionarEstudiantesId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para actualizar o agrega un estudiante nuevo
        /// </summary>
        /// <param name="value">Modelo a guardar</param>
        /// <returns>Devuelve el modelo que se envio</returns>
        // POST api/<EstudiantesController>
        [HttpPost]
        public async Task<ActionResult<Estudiantes>> Post([FromBody] Estudiantes value)
        {
            try
            {
                return Ok(await _estudiantesSer.MergeEstudiantes(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Post)}");
            }
            return BadRequest();
        }

        //// PUT api/<EstudiantesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EstudiantesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
