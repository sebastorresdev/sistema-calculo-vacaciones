using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Interfaces;
using Vacaciones.Negocios.Interfaces;

namespace Vacaciones.Negocios.Services;
public class TipoEmpleadoService : ITipoEmpleadoService
{
    private readonly ITipoEmpleadoRepository _tipoEmpleadoRepository;

    public TipoEmpleadoService(ITipoEmpleadoRepository tipoEmpleadoRepository)
    {
        _tipoEmpleadoRepository = tipoEmpleadoRepository;
    }

    public IEnumerable<TipoEmpleado> GetAll()
        => _tipoEmpleadoRepository.GetAll();

    public TipoEmpleado? GetById(int id)
        => _tipoEmpleadoRepository.GetById(id);

    public void Save(TipoEmpleado tipoEmpleado)
        => _tipoEmpleadoRepository.Save(tipoEmpleado);

    public void Update(TipoEmpleado tipoEmpleado)
        => _tipoEmpleadoRepository.Update(tipoEmpleado);

    public void Delete(int id)
        => _tipoEmpleadoRepository.Delete(id);
}
