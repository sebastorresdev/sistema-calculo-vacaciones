using Vacaciones.Datos.Entities;
using Vacaciones.Frontend.Models.Departamento;

namespace Vacaciones.Frontend.Mappings;

public static class DepartamentoMapping
{
    public static DepartamentoViewModel ToDepartamentoViewModel(this Departamento departamento)
    {
        return new DepartamentoViewModel
        {
            Id = departamento.Id,
            Nombre = departamento.Nombre,
        };
    }

    public static Departamento ToDepartamento(this CreateDepartamentoViewModel createDepartamento)
    {
        return new Departamento
        {
            Nombre = createDepartamento.Nombre,
        };
    }

    public static EditDepartamentoViewModel ToEditDepartamentoViewModel(this Departamento departamento)
    {
        return new EditDepartamentoViewModel
        {
            Id = departamento.Id,
            Nombre = departamento.Nombre,
        };
    }

    public static Departamento ToDepartamento(this EditDepartamentoViewModel editDepartamento)
    {
        return new Departamento
        {
            Id = editDepartamento.Id,
            Nombre = editDepartamento.Nombre,
        };
    }
}
