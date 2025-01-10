using Api.Data.Models;
using System.Linq.Expressions;

namespace Api.Services.Interfaces.ProfesoresSer
{
    public interface IProfesoresSer
    {
        Task<IEnumerable<Profesores>> ListProfesores(Expression<Func<Profesores, bool>> Function);
        Task<Profesores> MergeProfesores(Profesores modelo);
        Task<Profesores> SeleccionarProfesoresId(int id);
    }
}
