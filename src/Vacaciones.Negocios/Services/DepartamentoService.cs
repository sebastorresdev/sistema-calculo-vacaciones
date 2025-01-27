using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Interfaces;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Negocios.Services;

public class DepartamentoService(IDepartamentoRepository departamentoRepository) : IDepartamentoService
{
    private readonly IDepartamentoRepository _departamentoRepository = departamentoRepository;

    public IEnumerable<Departamento> GetAll() 
        => _departamentoRepository.GetAll();

    public Departamento? GetById(int id) 
        => _departamentoRepository.GetById(id);

    public void Save(Departamento departamento)
    {
        ArgumentNullException.ThrowIfNull(departamento);

        _departamentoRepository.Save(departamento);
    }

    public void Update(Departamento departamento)
    {
        ArgumentNullException.ThrowIfNull(departamento);

        _departamentoRepository.Update(departamento);
    }

    public void Delete(int id)
    {
        var departamento = _departamentoRepository.GetById(id);

        ArgumentNullException.ThrowIfNull(departamento);

        _departamentoRepository.Delete(id);
    }
}