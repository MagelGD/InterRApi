using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Data.Repositories.Interfaces.EstudiantesRep
{
    public interface IEstudiantesRep
    {
        Task<IEnumerable<Estudiantes>> ListEstudiantes (Expression<Func<Estudiantes, bool>> Function);
        Task<Estudiantes> MergeEstudiantes(Estudiantes modelo);

        Task<Estudiantes> SeleccionarEstudiantesId (int id);
    }
}
