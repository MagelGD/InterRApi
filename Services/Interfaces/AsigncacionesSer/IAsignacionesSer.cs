using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Services.Interfaces.AsigncacionesSer
{
    public interface IAsignacionesSer
    {
        Task<IEnumerable<Asignaciones>> ListAsignaciones(Expression<Func<Asignaciones, bool>> Function);
        Task<Asignaciones> MergeAsignaciones(Asignaciones modelo);
        Task<Asignaciones> SeleccionarAsignacionesId(int id);
    }
}
