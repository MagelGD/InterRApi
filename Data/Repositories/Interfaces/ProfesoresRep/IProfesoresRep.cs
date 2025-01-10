using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Interfaces.ProfesoresRep
{
    public interface IProfesoresRep
    {
        Task<IEnumerable<Profesores>> ListProfesores (Expression<Func<Profesores, bool>> Function);
        Task<Profesores> MergeProfesores(Profesores modelo);
        Task<Profesores> SeleccionarProfesoresId(int  id);
    }
}
