using Api.Data.Models;
using Api.Data.Repositories.Interfaces.ProfesoresRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones.ProfesoresImp
{
    public class ProfesoresImp :IProfesoresRep
    {
        private readonly UniversidadContext _Context;
        private readonly ILogger _logger;

        public ProfesoresImp(UniversidadContext universidadContext , ILogger<ProfesoresImp> logger)
        {
            _Context = universidadContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Profesores>> ListProfesores(Expression<Func<Profesores, bool>> Function)
        {
            IEnumerable<Profesores> Resultado = new List<Profesores>();
            try
            {
                var Qry = _Context.Profesores.AsQueryable();
                if (Function != default)
                {
                    Qry = Qry.Where(Function);
                }
                Resultado = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListProfesores)}");
            }
            return Resultado;
        }

        public async Task<Profesores> MergeProfesores(Profesores modelo)
        {
            Profesores Resultado = new();
            try
            {
                if(modelo.IdProfesor == 0)
                {
                    modelo.FechaCreacion = DateTime.Now;
                    _Context.Profesores.Add(modelo);
                }
                else
                {
                    _Context.Update(modelo);
                }
                if(await _Context.SaveChangesAsync()> 0)
                {
                    _Context.Entry(modelo).State = EntityState.Detached;
                    Resultado = modelo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeProfesores)}");
            }
            return Resultado;
        }

        public async Task<Profesores> SeleccionarProfesoresId(int id)
        {
            Profesores Resultado = new();
            try
            {
                var Qry = await _Context.Profesores.Where(x => x.IdProfesor.Equals(id)).SingleOrDefaultAsync();
                return Qry ?? Resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarProfesoresId)}");
            }
            return Resultado;
        }
    }
}
