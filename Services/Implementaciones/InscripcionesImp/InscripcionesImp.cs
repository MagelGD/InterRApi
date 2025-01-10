using Api.Data.Models;
using Api.Data.Repositories.Interfaces.InscripcionesRep;
using Api.Services.Interfaces.InscripcionesSer;
using System.Linq.Expressions;

namespace Api.Services.Implementaciones.InscripcionesImp
{
    public class InscripcionesImp : IInscripcionesSer
    {
        private readonly IInscripcionesRep _inscripcionesRep;
        private readonly ILogger _logger;

        public InscripcionesImp(IInscripcionesRep inscripcionesRep, ILogger<InscripcionesImp> logger)
        {
            _inscripcionesRep = inscripcionesRep;
            _logger = logger;
        }

        public async Task<IEnumerable<Inscripciones>> ListInscripciones(Expression<Func<Inscripciones, bool>> Function)
        {
            try
            {
                return await _inscripcionesRep.ListInscripciones(Function);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListInscripciones)}");
            }
            return default;
        }

        public async Task<Inscripciones> MergeInscripciones(Inscripciones modelo)
        {
            try
            {
                return await _inscripcionesRep.MergeInscripciones(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeInscripciones)}");
            }
            return modelo;
        }

        public async Task<Inscripciones> SeleccionarInscripcionesId(int id)
        {
            try
            {
                return await _inscripcionesRep.SeleccionarInscripcionesId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarInscripcionesId)}");
            }
            return default;
        }
    }
}
