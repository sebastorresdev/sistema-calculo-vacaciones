using System.ComponentModel.DataAnnotations;

namespace Vacaciones.Frontend.Models.TipoEmpleado;

public class EditTipoEmpleadoViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El campo Días por año es obligatorio")]
    [Range(10, 30, ErrorMessage = "El campo Días por año debe ser un número entre 10 y 30")]
    public int DiasPorAnio { get; set; }
}
