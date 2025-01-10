using Api.Data.Models;
using Api.Data.Repositories.Interfaces.EstudiantesRep;
using Api.Services.Interfaces.EstudiantesSer;
using System.Linq.Expressions;

namespace Api.Services.Implementaciones.EstudiantesImp
{
    public class EstudiantesImp : IEstudiantesSer
    {
        private readonly IEstudiantesRep _estudiantesRep;
        private readonly ILogger _logger;

        public EstudiantesImp(IEstudiantesRep estudiantesRep, ILogger<EstudiantesImp> logger)
        {
            _estudiantesRep = estudiantesRep;
            _logger = logger;
        }

        public async Task<IEnumerable<Estudiantes>> ListEstudiantes(Expression<Func<Estudiantes, bool>> Function)
        {
            try
            {
                return await _estudiantesRep.ListEstudiantes(Function);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListEstudiantes)}");
            }
            return default;
        }

        public async Task<Estudiantes> MergeEstudiantes(Estudiantes modelo)
        {
            try
            {
                return await _estudiantesRep.MergeEstudiantes(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeEstudiantes)}");
            }
            return modelo;
        }

        public async Task<Estudiantes> SeleccionarEstudiantesId(int id)
        {
            try
            {
                return await _estudiantesRep.SeleccionarEstudiantesId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {SeleccionarEstudiantesId}");
            }
            return default;
        }
    }
}
