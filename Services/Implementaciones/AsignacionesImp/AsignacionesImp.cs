using Api.Data.Models;
using Api.Data.Repositories.Interfaces.AsginacionesRep;
using Api.Services.Interfaces.AsigncacionesSer;
using System.Linq.Expressions;

namespace Api.Services.Implementaciones.AsignacionesImp
{
    public class AsignacionesImp : IAsignacionesSer
    {
        private readonly IAsignacionesRep _IASignacionesRep;
        private readonly ILogger _logger;

        public AsignacionesImp(IAsignacionesRep asignacionesRep, ILogger<AsignacionesImp> logger)
        {
            _IASignacionesRep = asignacionesRep;
            _logger = logger;
        }

        public async Task<IEnumerable<Asignaciones>> ListAsignaciones(Expression<Func<Asignaciones, bool>> Function)
        {
            try
            {
                return await _IASignacionesRep.ListAsignaciones(Function);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListAsignaciones)}");
            }
            return default;
        }

        public async Task<Asignaciones> MergeAsignaciones(Asignaciones modelo)
        {
            try
            {
                return await _IASignacionesRep.MergeAsignaciones(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeAsignaciones)}");
            }
            return modelo;
        }

        public async Task<Asignaciones> SeleccionarAsignacionesId(int id)
        {
            try
            {
                return await _IASignacionesRep.SeleccionarAsignacionesId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarAsignacionesId)}");
            }
            return default;
        }
    }
}
