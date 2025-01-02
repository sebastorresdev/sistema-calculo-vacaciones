namespace Vacaciones.Datos.Entities;

public class Empleado
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string? ApellidoMaterno { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string CorreoElectronico { get; set; } = null!;
    public int IdDepartamento { get; set; }
    public int IdTipoEmpleado { get; set; }
    public bool EstaActivo { get; set; }
}