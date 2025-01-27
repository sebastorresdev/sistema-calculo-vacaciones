using Vacaciones.Datos.Entities;

namespace Vacaciones.Datos.Interfaces;

public interface ITipoEmpleadoRepository
{
    IEnumerable<TipoEmpleado> GetAll();
    TipoEmpleado? GetById(int id);
    void Save(TipoEmpleado tipoEmpleado);
    void Update(TipoEmpleado tipoEmpleado);
    void Delete(int id);
}