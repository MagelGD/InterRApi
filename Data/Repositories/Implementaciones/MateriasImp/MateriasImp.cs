using Api.Data.Models;
using Api.Data.Repositories.Interfaces.MateriasRep;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Implementaciones.MateriasImp
{
    public class MateriasImp : IMateriasRep
    {
        private readonly UniversidadContext _Context;
        private readonly ILogger _logger;

        public MateriasImp(UniversidadContext universidadContext, ILogger<MateriasImp> logger)
        {
            _Context = universidadContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Materias>> ListMaterias(Expression<Func<Materias, bool>> Function)
        {
            IEnumerable<Materias> Resultado = new List<Materias>();
            try
            {
                var Qry = _Context.Materias.AsQueryable();
                if (Function != default)
                {
                    Qry = Qry.Where(Function);
                }
                Resultado = await Qry.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(ListMaterias)}");
            }
            return Resultado;
        }

        public async Task<Materias> MergeMaterias(Materias modelo)
        {
            Materias Resultado = new();
            try
            {
                if (modelo.IdMateria == 0)
                {
                    modelo.FechaCreacion = DateTime.Now;
                    _Context.Materias.Add(modelo);
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
                _logger.LogError(ex, $"Error en el metodo {nameof(MergeMaterias)}");
            }
            return Resultado;
        }

        public async Task<Materias> SeleccionarMateriasId(int id)
        {
            Materias Resultado = new();
            try
            {
                var Qry = await _Context.Materias.Where(x => x.IdMateria.Equals(id)).SingleOrDefaultAsync();
                return Qry ?? Resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en el metodo {nameof(SeleccionarMateriasId)}");
            }
            return Resultado;
        }
    }
}
