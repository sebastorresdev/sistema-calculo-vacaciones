namespace Vacaciones.Datos.Entities;

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public bool EstaActivo { get; set; }
}