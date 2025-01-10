using Api.Data.Repositories.Implementaciones.AsignacionesImp;
using Api.Data.Repositories.Implementaciones.EstudiantesImp;
using Api.Data.Repositories.Implementaciones.InscripcionesImp;
using Api.Data.Repositories.Implementaciones.MateriasImp;
using Api.Data.Repositories.Implementaciones.ProfesoresImp;
using Api.Data.Repositories.Interfaces.AsginacionesRep;
using Api.Data.Repositories.Interfaces.EstudiantesRep;
using Api.Data.Repositories.Interfaces.InscripcionesRep;
using Api.Data.Repositories.Interfaces.MateriasRep;
using Api.Data.Repositories.Interfaces.ProfesoresRep;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.Data.Repositories.ConfigurarRepositories
{
    public static class ConfigurarRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped<IEstudiantesRep, EstudiantesImp>();
            services.TryAddScoped<IProfesoresRep, ProfesoresImp>();
            services.TryAddScoped<IMateriasRep, MateriasImp>();
            services.TryAddScoped<IAsignacionesRep, AsignacionesImp>();
            services.TryAddScoped<IInscripcionesRep, InscripcionesImp>();
            return services;
        }
    }
}
