using Api.Data.Models;
using Api.Data.Repositories.Interfaces.ProfesoresRep;
using Api.Services.Interfaces.ProfesoresSer;
using System.Linq.Expressions;

namespace Api.Services.Implementaciones.ProfesoresImp
{
    public class ProfesoresImp : IProfesoresSer
    {
        private readonly IProfesoresRep _profesoresRep;
        private readonly ILogger _logger;

        public ProfesoresImp(IProfesoresRep profesoresRep, ILogger<ProfesoresImp> logger)
        {
            _logger = logger;
            _profesoresRep = profesoresRep;
        }

        public async Task<IEnumerable<Profesores>> ListProfesores(Expression<Func<Profesores, bool>> Function)
        {
            try
            {
                return await _profesoresRep.ListProfesores(Function);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListProfesores)}");
            }
            return default;
        }

        public async Task<Profesores> MergeProfesores(Profesores modelo)
        {
            try
            {
                return await _profesoresRep.MergeProfesores(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeProfesores)}");
            }
            return modelo;
        }

        public async Task<Profesores> SeleccionarProfesoresId(int id)
        {
            try
            {
                return await _profesoresRep.SeleccionarProfesoresId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarProfesoresId)}");
            }
            return default;
        }
    }
}
