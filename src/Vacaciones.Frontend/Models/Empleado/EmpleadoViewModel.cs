namespace Vacaciones.Frontend.Models.Empleado;

public class EmpleadoViewModel
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string FechaNacimiento { get; set; } = null!;
    public string FechaIngreso { get; set; } = null!;
    public string CorreoElectronico { get; set; } = null!;
    public string Departamento { get; set; } = null!;
    public string TipoEmpleado { get; set; } = null!;
}
