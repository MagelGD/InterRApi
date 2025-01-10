using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Interfaces.AsginacionesRep
{
    public interface IAsignacionesRep
    {
        Task<IEnumerable<Asignaciones>> ListAsignaciones (Expression<Func<Asignaciones, bool>> Function);
        Task<Asignaciones> MergeAsignaciones(Asignaciones modelo);
        Task<Asignaciones> SeleccionarAsignacionesId(int id);
    }
}
