using System.ComponentModel.DataAnnotations;

namespace Vacaciones.Frontend.Models.Departamento;

public class CreateDepartamentoViewModel
{
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public required string Nombre { get; init; }
}