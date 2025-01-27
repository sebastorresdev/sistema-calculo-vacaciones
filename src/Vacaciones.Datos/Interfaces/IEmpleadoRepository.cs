using Vacaciones.Datos.Entities;

namespace Vacaciones.Datos.Interfaces;
public interface IEmpleadoRepository
{
    IEnumerable<Empleado> GetAll();
    Empleado? GetById(int id);
    void Create(Empleado departamento);
    void Update(Empleado departamento);
    void Delete(int id);
}
