using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Interfaces;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Negocios.Services;
public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _empleadoRepository;

    public EmpleadoService(IEmpleadoRepository empleadoRepository)
    {
        _empleadoRepository = empleadoRepository;
    }

    public void Create(Empleado empleado)
    {
        _empleadoRepository.Create(empleado);
    }

    public void Delete(int id)
    {
        _empleadoRepository.Delete(id);
    }

    public IEnumerable<Empleado> GetAll()
    {
        return _empleadoRepository.GetAll();
    }

    public Empleado? GetById(int id)
    {
        return _empleadoRepository.GetById(id);
    }

    public void Update(Empleado empleado)
    {
        _empleadoRepository.Update(empleado);
    }
}
