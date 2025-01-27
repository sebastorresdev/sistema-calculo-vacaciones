using Vacaciones.Datos.Entities;

namespace Vacaciones.Negocios.Interfaces;
public interface IEmpleadoService
{
    IEnumerable<Empleado> GetAll();
    Empleado? GetById(int id);
    void Create(Empleado empleado);
    void Update(Empleado empleado);
    void Delete(int id);
}
