using Api.Data.Models;
using Api.Data.Repositories.Interfaces.EstudiantesRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones.EstudiantesImp
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
                if (Function != default)
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

        public async Task<Estudiantes> MergeEstudiantes(Estudiantes modelo)
        {
            Estudiantes Resultado = new();
            try
            {
                if (modelo.IdEstudiante == 0)
                {
                    modelo.FechaCreacion = DateTime.Now;
                    _Context.Estudiantes.Add(modelo);
                }
                else
                {
                    _Context.Update(modelo);
                }
                if (await _Context.SaveChangesAsync() > 0)
                {
                    _Context.Entry(modelo).State = EntityState.Detached;
                    Resultado = modelo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeEstudiantes)}");
            }
            return Resultado;
        }

        public async Task<Estudiantes> SeleccionarEstudiantesId(int id)
        {
            Estudiantes Resultado = new();
            try
            {
                var Qry = await _Context.Estudiantes.Where(x => x.IdEstudiante.Equals(id)).SingleOrDefaultAsync();
                return Qry ?? Resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarEstudiantesId)}");
            }
            return Resultado;
        }
    }
}
