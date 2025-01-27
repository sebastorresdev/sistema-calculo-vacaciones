namespace Vacaciones.Datos.Entities;
public class TipoEmpleado
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int DiasPorAnio { get; set; }
    public bool EstaActivo { get; set; }
}
