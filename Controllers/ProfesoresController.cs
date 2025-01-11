using Api.Data.Models;
using Api.Services.Interfaces.ProfesoresSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesoresSer _profesoresSer;
        private readonly ILogger _logger;

        public ProfesoresController(IProfesoresSer profesoresSer, ILogger<ProfesoresController> logger)
        {
            _logger = logger;
            _profesoresSer = profesoresSer;
        }

        /// <summary>
        /// Metodo para listar todos los profesores
        /// </summary>
        /// <returns>Devuelve una lista</returns>
        // GET: api/<ProfesoresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesores>>> Get()
        {
            try
            {
                return Ok(await _profesoresSer.ListProfesores(null));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para seleccionar profesor especificamente
        /// </summary>
        /// <param name="id">id de profesor a selecionar</param>
        /// <returns>devuelve el modelo del profesor seleccionado</returns>
        // GET api/<ProfesoresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesores>> Get(int id)
        {
            try
            {
                return Ok(await _profesoresSer.SeleccionarProfesoresId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para actualizar o agregar un nuevo registro en la tabla profesores
        /// </summary>
        /// <param name="value">Modelo de profesores</param>
        /// <returns>Devuelve el modelo agregado o actualizado</returns>
        // POST api/<ProfesoresController>
        [HttpPost]
        public async Task<ActionResult<Profesores>> Post([FromBody] Profesores value)
        {
            try
            {
                return Ok(await _profesoresSer.MergeProfesores(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Post)}");
            }
            return BadRequest();
        }

        //// PUT api/<ProfesoresController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProfesoresController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
