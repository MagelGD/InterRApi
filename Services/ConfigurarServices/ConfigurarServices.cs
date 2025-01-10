using Api.Services.Implementaciones.AsignacionesImp;
using Api.Services.Implementaciones.EstudiantesImp;
using Api.Services.Implementaciones.InscripcionesImp;
using Api.Services.Implementaciones.MateriasImp;
using Api.Services.Implementaciones.ProfesoresImp;
using Api.Services.Interfaces.AsigncacionesSer;
using Api.Services.Interfaces.EstudiantesSer;
using Api.Services.Interfaces.InscripcionesSer;
using Api.Services.Interfaces.MateriasSer;
using Api.Services.Interfaces.ProfesoresSer;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.Services.ConfigurarServices
{
    public static class ConfigurarServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEstudiantesSer, EstudiantesImp>();
            services.AddScoped<IMateriasSer, MateriasImp>();
            services.AddScoped<IProfesoresSer, ProfesoresImp>();
            services.AddScoped<IAsignacionesSer, AsignacionesImp>();
            services.AddScoped<IInscripcionesSer, InscripcionesImp>();
            return services;
        }
    }
}
