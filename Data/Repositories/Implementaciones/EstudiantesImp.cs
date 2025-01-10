using Api.Data.Models;
using Api.Data.Repositories.Interfaces.EstudiantesRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones
{
    public class EstudiantesImp : IEstudiantesRep
    {
        private readonly UniversidadContext _Context;
        private readonly ILogger _logger;

        public EstudiantesImp(UniversidadContext universidadContext, ILogger<EstudiantesImp> logger)
        {
            _Context = universidadContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Estudiantes>> ListEstudiantes(Expression<Func<Estudiantes, bool>> Function)
        {
            IEnumerable<Estudiantes> Resultado = new List<Estudiantes>();
            try
            {
                var Qry = _Context.Estudiantes.AsQueryable();
                if(Function != default)
                {
                    Qry = Qry.Where(Function);
                }
                Resultado = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error en el metodo {nameof(ListEstudiantes)}");
            }
            return Resultado;
        }

        public Task<Estudiantes> MergeEstudiantes(Estudiantes modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiantes> SeleccionarEstudiantesId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
