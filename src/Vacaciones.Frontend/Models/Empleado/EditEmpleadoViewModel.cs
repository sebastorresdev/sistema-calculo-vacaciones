using System.ComponentModel.DataAnnotations;

namespace Vacaciones.Frontend.Models.Empleado;

public class EditEmpleadoViewModel
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string ApellidoPaterno { get; set; } = null!;
    public string? ApellidoMaterno { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int IdDepartamento { get; set; }
    public int IdTipoEmpleado { get; set; }
    [Required]
    public string Correo { get; set; } = null!;
}
