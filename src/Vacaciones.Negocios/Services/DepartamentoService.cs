using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Repositories;

namespace Vacaciones.Negocios.Services;

public class DepartamentoService
{
    private readonly DepartamentoRepository _departamentoRepository;

    public DepartamentoService(DepartamentoRepository departamentoRepository)
        => _departamentoRepository = departamentoRepository;

    public IEnumerable<Departamento> GetDepartamentos() => _departamentoRepository.GetAll(); 

    public Departamento? GetDepartamentoById(int id) => _departamentoRepository.GetById(id);

    public void AddDepartamento(Departamento departamento)
    {
        if (departamento == null)
            throw new ArgumentNullException(nameof(departamento));

        _departamentoRepository.Add(departamento);
    }

    public void UpdateDepartamento(Departamento departamento)
    {
        if (departamento == null)
            throw new ArgumentNullException(nameof(departamento));

        _departamentoRepository.Update(departamento);
    }

    public void DeleteDepartamento(int id)
    {
        var departamento = _departamentoRepository.GetById(id);

        if (departamento == null)
            throw new ArgumentNullException(nameof(departamento));

        _departamentoRepository.Delete(id);
    }
}