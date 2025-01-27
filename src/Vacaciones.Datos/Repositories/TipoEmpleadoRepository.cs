using Microsoft.Data.SqlClient;
using Vacaciones.Datos.Data;
using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Interfaces;

namespace Vacaciones.Datos.Repositories;
public class TipoEmpleadoRepository : ITipoEmpleadoRepository
{
    private readonly Connection _connection;

    public TipoEmpleadoRepository(Connection connection)
    {
        _connection = connection;
    }

    public IEnumerable<TipoEmpleado> GetAll()
    {
        using var conexion = _connection.GetConnection();

        var query = "SELECT * FROM tipos_empleados WHERE esta_activo = 1";

        using var command = new SqlCommand(query, conexion);

        conexion.Open();

        using var reader = command.ExecuteReader();

        while(reader.Read())
        {
            yield return new TipoEmpleado
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                DiasPorAnio = reader.GetInt32(2),
                EstaActivo = reader.GetBoolean(3)
            };
        }   
    }

    public TipoEmpleado? GetById(int id)
    {
        using var conexion = _connection.GetConnection();

        var query = "SELECT * FROM tipos_empleados WHERE id=@id AND esta_activo = 1";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@id", id);

        conexion.Open();

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new TipoEmpleado
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                DiasPorAnio = reader.GetInt32(2),
                EstaActivo = reader.GetBoolean(3)
            };
        }

        return null;
    }

    public void Save(TipoEmpleado tipoEmpleado)
    {
        using var conexion = _connection.GetConnection();

        var query = "INSERT INTO tipos_empleados (nombre, dias_por_anio) VALUES (@nombre, @dias_por_anio)";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@nombre", tipoEmpleado.Nombre);
        command.Parameters.AddWithValue("@dias_por_anio", tipoEmpleado.DiasPorAnio);

        conexion.Open();

        command.ExecuteNonQuery();
    }

    public void Update(TipoEmpleado tipoEmpleado)
    {
        using var conexion = _connection.GetConnection();

        var query = "UPDATE tipos_empleados SET nombre = @nombre, dias_por_anio = @dias_por_anio WHERE id = @id AND esta_activo = 1";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@id", tipoEmpleado.Id);
        command.Parameters.AddWithValue("@nombre", tipoEmpleado.Nombre);
        command.Parameters.AddWithValue("@dias_por_anio", tipoEmpleado.DiasPorAnio);

        conexion.Open();

        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conexion = _connection.GetConnection();

        var query = "UPDATE tipos_empleados SET esta_activo = 0 WHERE id = @id AND esta_activo = 1";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@id", id);

        conexion.Open();

        command.ExecuteNonQuery();
    }
}
