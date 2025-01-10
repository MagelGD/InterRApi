using Api.Data.Models;
using Api.Data.Repositories.Interfaces.MateriasRep;
using Api.Services.Interfaces.MateriasSer;
using System.Linq.Expressions;

namespace Api.Services.Implementaciones.MateriasImp
{
    public class MateriasImp : IMateriasSer
    {
        private readonly IMateriasRep _materiasRep;
        private readonly ILogger _logger;

        public MateriasImp(IMateriasRep materiasRep, ILogger<MateriasImp> logger)
        {
            _logger = logger;
            _materiasRep = materiasRep;
        }

        public async Task<IEnumerable<Materias>> ListMaterias(Expression<Func<Materias, bool>> Function)
        {
            try
            {
                return await _materiasRep.ListMaterias(Function);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListMaterias)}");
            }
            return default;
        }

        public async Task<Materias> MergeMaterias(Materias modelo)
        {
            try
            {
                return await _materiasRep.MergeMaterias(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeMaterias)}");
            }
            return modelo;
        }

        public async Task<Materias> SeleccionarMateriasId(int id)
        {
            try
            {
                return await _materiasRep.SeleccionarMateriasId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarMateriasId)}");
            }
            return default;
        }
    }
}
