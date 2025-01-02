using System.ComponentModel.DataAnnotations;

namespace Vacaciones.Frontend.Models.Departamentos;

public record CreateDepartamentoViewModel
{
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public required string Nombre { get; init; }
}