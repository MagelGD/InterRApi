using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Services.Interfaces.MateriasSer
{
    public interface IMateriasSer
    {
        Task<IEnumerable<Materias>> ListMaterias(Expression<Func<Materias, bool>> Function);
        Task<Materias> MergeMaterias(Materias modelo);

        Task<Materias> SeleccionarMateriasId(int id);
    }
}
