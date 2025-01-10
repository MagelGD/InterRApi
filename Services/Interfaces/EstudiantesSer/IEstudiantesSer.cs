using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Services.Interfaces.EstudiantesSer
{
    public interface IEstudiantesSer
    {
        Task<IEnumerable<Estudiantes>> ListEstudiantes(Expression<Func<Estudiantes, bool>> Function);
        Task<Estudiantes> MergeEstudiantes(Estudiantes modelo);

        Task<Estudiantes> SeleccionarEstudiantesId(int id);
    }
}
