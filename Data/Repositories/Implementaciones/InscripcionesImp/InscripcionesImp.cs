using Api.Data.Models;
using Api.Data.Repositories.Interfaces.InscripcionesRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones.InscripcionesImp
{
    public class InscripcionesImp : IInscripcionesRep
    {
        private readonly UniversidadContext _Context;
        private readonly ILogger _logger;

        public InscripcionesImp(UniversidadContext universidadContext, ILogger<InscripcionesImp> logger)
        {
            _Context = universidadContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Inscripciones>> ListInscripciones(Expression<Func<Inscripciones, bool>> Function)
        {
            IEnumerable<Inscripciones> Resultado = new List<Inscripciones>();
            try
            {
                var Qry = _Context.Inscripciones.Include(x => x.IdMateriaNavigation).Include(x => x.IdEstudianteNavigation).AsQueryable();
                if (Function != default)
                {
                    Qry = Qry.Where(Function);
                }
                Resultado = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListInscripciones)}");
            }
            return Resultado;
        }

        public async Task<Inscripciones> MergeInscripciones(Inscripciones modelo)
        {
            Inscripciones Resultado = new();
            try
            {
                if(modelo.IdInscripcion == 0)
                {
                    modelo.FechaCreacion = DateTime.Now;
                    _Context.Inscripciones.Add(modelo);
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
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeInscripciones)}");
            }
            return Resultado;
        }

        public async Task<Inscripciones> SeleccionarInscripcionesId(int id)
        {
            Inscripciones Resultado = new();
            try
            {
                var Qry = await _Context.Inscripciones.Include(x => x.IdMateriaNavigation).Include(x => x.IdEstudianteNavigation).Where(x => x.IdInscripcion.Equals(id)).SingleOrDefaultAsync();
                return Qry ?? Resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarInscripcionesId)}");
            }
            return Resultado;
        }
    }
}
