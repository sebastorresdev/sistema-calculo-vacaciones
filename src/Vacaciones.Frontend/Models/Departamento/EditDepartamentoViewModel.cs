using System.ComponentModel.DataAnnotations;

namespace Vacaciones.Frontend.Models.Departamento;

public class EditDepartamentoViewModel
{
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int Id { get; init; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public required string Nombre { get; init; }
}