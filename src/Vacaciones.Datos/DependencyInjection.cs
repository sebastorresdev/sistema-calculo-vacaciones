using Microsoft.Extensions.DependencyInjection;
using Vacaciones.Datos.Data;
using Vacaciones.Datos.Interfaces;
using Vacaciones.Datos.Repositories;

namespace Vacaciones.Datos;

public static class DependencyInjection
{
    public static IServiceCollection AddDatos(this IServiceCollection services)
    {
        services.AddScoped<Connection>();
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        services.AddScoped<ITipoEmpleadoRepository, TipoEmpleadoRepository>();
        services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

        return services;
    }
}