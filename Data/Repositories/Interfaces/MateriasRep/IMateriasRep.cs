using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Interfaces.MateriasRep
{
    public interface IMateriasRep
    {
        Task<IEnumerable<Materias>> ListMaterias (Expression<Func<Materias, bool>> Function);
        Task<Materias> MergeMaterias (Materias modelo);

        Task<Materias> SeleccionarMateriasId (int id);
    }
}
