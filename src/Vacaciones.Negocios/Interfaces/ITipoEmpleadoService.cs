using Vacaciones.Datos.Entities;

namespace Vacaciones.Negocios.Interfaces;
public interface ITipoEmpleadoService
{
    void Delete(int id);
    IEnumerable<TipoEmpleado> GetAll();
    TipoEmpleado? GetById(int id);
    void Save(TipoEmpleado tipoEmpleado);
    void Update(TipoEmpleado tipoEmpleado);
}