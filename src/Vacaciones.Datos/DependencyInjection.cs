using Microsoft.Extensions.DependencyInjection;
using Vacaciones.Datos.Data;
using Vacaciones.Datos.Repositories;

namespace Vacaciones.Datos;

public static class DependencyInjection
{
    public static IServiceCollection AddDatos(this IServiceCollection services)
    {
        services.AddScoped<VacacionesDbConnection>();
        services.AddScoped<DepartamentoRepository>();

        return services;
    }
}