using Vacaciones.Datos.Entities;
using Vacaciones.Frontend.Models.TipoEmpleado;

namespace Vacaciones.Frontend.Mappings;

public static class TipoEmpleadoMapping
{
    public static TipoEmpleadoViewModel ToTipoEmpleadoViewModel(this TipoEmpleado tipoEmpleado)
    {
        return new TipoEmpleadoViewModel
        {
            Id = tipoEmpleado.Id,
            Nombre = tipoEmpleado.Nombre
        };
    }
    public static TipoEmpleado ToTipoEmpleado(this CreateTipoEmpleadoViewModel createTipoEmpleadoViewModel)
    {
        return new TipoEmpleado
        {
            Nombre = createTipoEmpleadoViewModel.Nombre
        };
    }

    public static TipoEmpleado ToTipoEmpleado(this EditTipoEmpleadoViewModel editTipoEmpleadoViewModel)
    {
        return new TipoEmpleado
        {
            Id = editTipoEmpleadoViewModel.Id,
            Nombre = editTipoEmpleadoViewModel.Nombre,
            DiasPorAnio = editTipoEmpleadoViewModel.DiasPorAnio
        };
    }

    public static EditTipoEmpleadoViewModel ToEditTipoEmpleadoViewModel(this TipoEmpleado tipoEmpleado)
    {
        return new EditTipoEmpleadoViewModel
        {
            Id = tipoEmpleado.Id,
            Nombre = tipoEmpleado.Nombre,
            DiasPorAnio = tipoEmpleado.DiasPorAnio,
        };
    }
}
