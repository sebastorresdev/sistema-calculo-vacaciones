using Vacaciones.Datos.Entities;

namespace Vacaciones.Datos.Interfaces;

public interface IDepartamentoRepository
{
    IEnumerable<Departamento> GetAll();
    Departamento? GetById(int id);
    void Save(Departamento departamento);
    void Update(Departamento departamento);
    void Delete(int id);

}