using Microsoft.Extensions.DependencyInjection;
using Vacaciones.Negocios.Interfaces;
using Vacaciones.Negocios.Services;

namespace Vacaciones.Negocios;

public static class DependencyInjection
{
    public static IServiceCollection AddNegocios(this IServiceCollection services)
    {
        services.AddScoped< IDepartamentoService, DepartamentoService >();
        services.AddScoped< ITipoEmpleadoService, TipoEmpleadoService >();
        services.AddScoped< IEmpleadoService, EmpleadoService >();

        return services;
    }
}