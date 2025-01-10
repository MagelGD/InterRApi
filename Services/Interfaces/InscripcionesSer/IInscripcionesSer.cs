using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Services.Interfaces.InscripcionesSer
{
    public interface IInscripcionesSer
    {
        Task<IEnumerable<Inscripciones>> ListInscripciones(Expression<Func<Inscripciones, bool>> Function);
        Task<Inscripciones> MergeInscripciones(Inscripciones modelo);
        Task<Inscripciones> SeleccionarInscripcionesId(int id);
    }
}
