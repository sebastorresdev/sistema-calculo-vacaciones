using Vacaciones.Datos.Entities;
using Vacaciones.Frontend.Models.Empleado;

namespace Vacaciones.Frontend.Mappings;

public static class EmpleadoMapping
{
    public static EmpleadoViewModel ToEmpleadoViewModel(this Empleado empleado)
    {
        return new()
        {
            Id = empleado.Id,
            NombreCompleto = $"{empleado.NombreCompleto} {empleado.ApellidoPaterno} {empleado.ApellidoMaterno}",
            FechaNacimiento = empleado.FechaNacimiento.ToShortDateString(),
            FechaIngreso = empleado.FechaIngreso.ToShortDateString(),
            CorreoElectronico = empleado.CorreoElectronico,
            TipoEmpleado = empleado.NombreTipoEmpleado is not null ? empleado.NombreTipoEmpleado : throw new NullReferenceException("Error al obtener el tipo de empleado"),
            Departamento = empleado.NombreDepartamento is not null ? empleado.NombreDepartamento : throw new NullReferenceException("Error al obtener el departamento")
        };
    }

    public static Empleado ToEmpleado(this CreateEmpleadoViewModel createEmpleado)
    {
        return new()
        {
            Id = 0,
            NombreCompleto = createEmpleado.Nombre,
            ApellidoPaterno = createEmpleado.ApellidoPaterno,
            ApellidoMaterno = createEmpleado.ApellidoMaterno,
            FechaNacimiento = createEmpleado.FechaNacimiento,
            FechaIngreso = createEmpleado.FechaIngreso,
            CorreoElectronico = createEmpleado.Correo,
            IdDepartamento = createEmpleado.IdDepartamento,
            IdTipoEmpleado = createEmpleado.IdTipoEmpleado,
            EstaActivo = true
        };
    }

    public static Empleado ToEmpleado(this EditEmpleadoViewModel editEmpleado)
    {
        return new()
        {
            Id = editEmpleado.Id,
            NombreCompleto = editEmpleado.Nombre,
            ApellidoPaterno = editEmpleado.ApellidoPaterno,
            ApellidoMaterno = editEmpleado.ApellidoMaterno,
            FechaNacimiento = editEmpleado.FechaNacimiento,
            FechaIngreso = editEmpleado.FechaIngreso,
            CorreoElectronico = editEmpleado.Correo,
            IdDepartamento = editEmpleado.IdDepartamento,
            IdTipoEmpleado = editEmpleado.IdTipoEmpleado,
            EstaActivo = true
        };
    }

    public static EditEmpleadoViewModel ToEditEmpleadoViewModel(this Empleado empleado)
    {
        return new()
        {
            Id = empleado.Id,
            Nombre = empleado.NombreCompleto,
            ApellidoPaterno = empleado.ApellidoPaterno,
            ApellidoMaterno = empleado.ApellidoMaterno,
            FechaNacimiento = empleado.FechaNacimiento,
            FechaIngreso = empleado.FechaIngreso,
            IdDepartamento = empleado.IdDepartamento,
            IdTipoEmpleado = empleado.IdTipoEmpleado,
            Correo = empleado.CorreoElectronico
        };
    }
}
