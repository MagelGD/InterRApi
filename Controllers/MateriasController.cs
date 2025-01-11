using Api.Data.Models;
using Api.Services.Interfaces.MateriasSer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriasSer _materiasSer;
        private readonly ILogger _logger;
        public MateriasController(IMateriasSer materiasSer, ILogger<MateriasController> logger)
        {
            _logger = logger;
            _materiasSer = materiasSer;
        }
        /// <summary>
        /// Metodo para listar todas las materias
        /// </summary>
        /// <returns>Devuele una lista de materias</returns>
        // GET: api/<MateriasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materias> Get()
        {
            try
            {
                return Ok(await _materiasSer.ListMaterias(null));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }
        /// <summary>
        /// Metodo que devuelve una materia especifica
        /// </summary>
        /// <param name="id">Id de materia</param>
        /// <returns>Devuelve un modelo de materia especifico</returns>
        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materias>> Get(int id)
        {
            try
            {
                return Ok(await _materiasSer.SeleccionarMateriasId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Get)}");
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo para actualizar o agregar una materia nueva
        /// </summary>
        /// <param name="value">Modelo agregar o actualizar</param>
        /// <returns>Devuelve el modelo</returns>
        // POST api/<MateriasController>
        [HttpPost]
        public async Task<ActionResult<Materias>> Post([FromBody] Materias value)
        {
            try
            {
                return Ok(await _materiasSer.MergeMaterias(value));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(Post)}");
            }
            return BadRequest();
        }

        //// PUT api/<MateriasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MateriasController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
