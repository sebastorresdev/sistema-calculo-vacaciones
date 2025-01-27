using Microsoft.Data.SqlClient;
using Vacaciones.Datos.Data;
using Vacaciones.Datos.Entities;
using Vacaciones.Datos.Interfaces;

namespace Vacaciones.Datos.Repositories;
public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly Connection _connection;

    public EmpleadoRepository(Connection connection)
    {
        _connection = connection;
    }

    public void Create(Empleado departamento)
    {
        using var conexion = _connection.GetConnection();

        var query = @"INSERT INTO empleados 
            (nombre_completo, apellido_paterno, apellido_materno, fecha_nacimiento, fecha_ingreso, id_departamento, id_tipo_empleado, correo_electronico) 
            VALUES (@nombre_completo, @apellido_paterno, @apellido_materno, @fecha_nacimiento, @fecha_ingreso, @id_departamento, @id_tipo_empleado, @correo_electronico)";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@nombre_completo", departamento.NombreCompleto);
        command.Parameters.AddWithValue("@apellido_paterno", departamento.ApellidoPaterno);
        command.Parameters.AddWithValue("@apellido_materno",
        string.IsNullOrEmpty(departamento.ApellidoMaterno) ? (object)DBNull.Value : departamento.ApellidoMaterno);
        command.Parameters.AddWithValue("@fecha_nacimiento", departamento.FechaNacimiento);
        command.Parameters.AddWithValue("@fecha_ingreso", departamento.FechaIngreso);
        command.Parameters.AddWithValue("@id_departamento", departamento.IdDepartamento);
        command.Parameters.AddWithValue("@id_tipo_empleado", departamento.IdTipoEmpleado);
        command.Parameters.AddWithValue("@correo_electronico", departamento.CorreoElectronico);

        conexion.Open();

        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conexion = _connection.GetConnection();

        var query = "UPDATE empleados SET esta_activo = 0 WHERE id = @id";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@id", id);

        conexion.Open();

        command.ExecuteNonQuery();
    }

    public IEnumerable<Empleado> GetAll()
    {
        using var conexion = _connection.GetConnection();

        var query = @"SELECT empleados.*, d.nombre AS departamento, t.nombre AS tipo_empleado FROM empleados 
                    INNER JOIN departamentos d ON empleados.id_departamento = d.id
                    INNER JOIN tipos_empleados t ON empleados.id_tipo_empleado = t.id
                    WHERE empleados.esta_activo = 1";

        using var command = new SqlCommand(query, conexion);

        conexion.Open();

        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Empleado
            {
                Id = reader.GetInt32(0),
                NombreCompleto = reader.GetString(1),
                ApellidoPaterno = reader.GetString(2),
                ApellidoMaterno = reader.IsDBNull(3) ? null : reader.GetString(3),
                FechaIngreso = reader.GetDateTime(4),
                FechaNacimiento = reader.GetDateTime(5),
                CorreoElectronico = reader.GetString(6),
                IdDepartamento = reader.GetInt32(7),
                IdTipoEmpleado = reader.GetInt32(8),
                NombreDepartamento = reader.GetString(11),
                NombreTipoEmpleado = reader.GetString(12)

            };
        }
    }

    public Empleado? GetById(int id)
    {
        using var conexion = _connection.GetConnection();

        var query = "SELECT * FROM empleados WHERE esta_activo = 1 AND id = @id";

        using var command = new SqlCommand(query, conexion);

        command.Parameters.AddWithValue("@id", id);

        conexion.Open();

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Empleado
            {
                Id = reader.GetInt32(0),
                NombreCompleto = reader.GetString(1),
                ApellidoPaterno = reader.GetString(2),
                ApellidoMaterno = reader.IsDBNull(3) ? null : reader.GetString(3),
                FechaIngreso = reader.GetDateTime(4),
                FechaNacimiento = reader.GetDateTime(5),
                CorreoElectronico = reader.GetString(6),
                IdDepartamento = reader.GetInt32(7),
                IdTipoEmpleado = reader.GetInt32(8),

            };
        }

        return null;
    }

    public void Update(Empleado departamento)
    {
        using var conexion = _connection.GetConnection();

        var query = @"UPDATE empleados SET 
            nombre_completo = @nombre_completo, 
            apellido_paterno = @apellido_paterno, 
            apellido_materno = @apellido_materno, 
            fecha_nacimiento = @fecha_nacimiento, 
            fecha_ingreso = @fecha_ingreso, 
            id_departamento = @id_departamento, 
            id_tipo_empleado = @id_tipo_empleado, 
            correo_electronico = @correo_electronico 
            WHERE id = @id";

        var command = new SqlCommand(query, conexion);
        
        command.Parameters.AddWithValue("@id", departamento.Id);
        command.Parameters.AddWithValue("@nombre_completo", departamento.NombreCompleto);
        command.Parameters.AddWithValue("@apellido_paterno", departamento.ApellidoPaterno);
        command.Parameters.AddWithValue("@apellido_materno",
        string.IsNullOrEmpty(departamento.ApellidoMaterno) ? (object)DBNull.Value : departamento.ApellidoMaterno);
        command.Parameters.AddWithValue("@fecha_nacimiento", departamento.FechaNacimiento);
        command.Parameters.AddWithValue("@fecha_ingreso", departamento.FechaIngreso);
        command.Parameters.AddWithValue("@id_departamento", departamento.IdDepartamento);
        command.Parameters.AddWithValue("@id_tipo_empleado", departamento.IdTipoEmpleado);
        command.Parameters.AddWithValue("@correo_electronico", departamento.CorreoElectronico);

        conexion.Open();

        command.ExecuteNonQuery();
    }
}
