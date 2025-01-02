using Microsoft.Extensions.DependencyInjection;
using Vacaciones.Negocios.Services;

namespace Vacaciones.Negocios;

public static class DependencyInjection
{
    public static IServiceCollection AddNegocios(this IServiceCollection services)
    {
        services.AddScoped<DepartamentoService>();

        return services;
    }
}