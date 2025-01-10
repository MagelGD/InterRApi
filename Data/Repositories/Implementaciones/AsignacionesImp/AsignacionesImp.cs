using Api.Data.Models;
using Api.Data.Repositories.Interfaces.AsginacionesRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones.AsignacionesImp
{
    public class AsignacionesImp : IAsignacionesRep
    {
        private readonly UniversidadContext _Context;
        private readonly ILogger _logger;

        public AsignacionesImp(UniversidadContext universidadContext, ILogger<AsignacionesImp> logger)
        {
            _Context = universidadContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Asignaciones>> ListAsignaciones(Expression<Func<Asignaciones, bool>> Function)
        {
            IEnumerable<Asignaciones> Resultado = new List<Asignaciones>();
            try
            {
                var Qry = _Context.Asignaciones.Include(x=> x.IdMateriaNavigation).Include(x=> x.IdProfesorNavigation).AsQueryable();
                if(Function != default)
                {
                    Qry = Qry.Where(Function);
                }
                Resultado = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListAsignaciones)}");
            }
            return Resultado;
        }

        public async Task<Asignaciones> MergeAsignaciones(Asignaciones modelo)
        {
            Asignaciones Resultado = new();
            try
            {
                if(modelo.IdAsignacion == 0)
                {
                    modelo.FechaCreacion = DateTime.Now;
                    _Context.Asignaciones.Add(modelo);
                }
                else
                {
                    _Context.Update(modelo);
                }
                if(await _Context.SaveChangesAsync() > 0)
                {
                    _Context.Entry(modelo).State = EntityState.Detached;
                    Resultado = modelo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeAsignaciones)}");
            }
            return Resultado;
        }

        public async Task<Asignaciones> SeleccionarAsignacionesId(int id)
        {
            Asignaciones Resultado = new();
            try
            {
                var Qry = await _Context.Asignaciones.Include(x=> x.IdMateriaNavigation).Include(x=> x.IdProfesorNavigation).Where(x => x.IdAsignacion.Equals(id)).SingleOrDefaultAsync();
                return Qry ?? Resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarAsignacionesId)}");
            }
            return Resultado;
        }
    }
}
