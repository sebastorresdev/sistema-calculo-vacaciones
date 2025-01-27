using Vacaciones.Datos.Entities;

namespace Vacaciones.Negocios.Interfaces;
public interface IDepartamentoService
{
    void Delete(int id);
    IEnumerable<Departamento> GetAll();
    Departamento? GetById(int id);
    void Save(Departamento departamento);
    void Update(Departamento departamento);
}