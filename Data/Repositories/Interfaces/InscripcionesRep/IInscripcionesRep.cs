using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Interfaces.InscripcionesRep
{
    public interface IInscripcionesRep
    {
        Task<IEnumerable<Inscripciones>> ListInscripciones(Expression<Func<Inscripciones, bool>> Function);
        Task<Inscripciones> MergeInscripciones(Inscripciones modelo);
        Task<Inscripciones> SeleccionarInscripcionesId(int id);
    }
}
