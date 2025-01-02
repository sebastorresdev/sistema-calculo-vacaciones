using Microsoft.Data.SqlClient;
using Vacaciones.Datos.Data;
using Vacaciones.Datos.Entities;

namespace Vacaciones.Datos.Repositories;

public class DepartamentoRepository
{
    private readonly VacacionesDbConnection _connection;

    public DepartamentoRepository(VacacionesDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Departamento> GetAll()
    {
        using var connection = _connection.GetConnection();

        SqlCommand command = new("SELECT * FROM Departamentos WHERE esta_activo = 1", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            yield return new Departamento
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
            };
        }
    }

    public Departamento? GetById(int id)
    {
        using var connection = _connection.GetConnection();

        SqlCommand command = new("SELECT * FROM Departamentos WHERE Id = @Id AND esta_activo = 1", connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        if(reader.Read())
        {
            return new Departamento
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                EstaActivo = reader.GetBoolean(2)
            };
        }

        return null;
    }

    public void Add(Departamento departamento)
    {
        using var connection = _connection.GetConnection();

        SqlCommand command = new("INSERT INTO Departamentos (nombre) VALUES (@Nombre)", connection);
        command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Update(Departamento departamento)
    {
        using var connection = _connection.GetConnection();

        SqlCommand command = new("UPDATE Departamentos SET nombre = @Nombre WHERE Id = @Id AND esta_activo = 1", connection);
        command.Parameters.AddWithValue("@Nombre", departamento.Nombre);
        command.Parameters.AddWithValue("@Id", departamento.Id);
        connection.Open();
        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = _connection.GetConnection();

        SqlCommand command = new("UPDATE Departamentos SET esta_activo = 0 WHERE Id = @Id AND esta_activo = 1", connection);
        command.Parameters.AddWithValue("@Id", id);
        connection.Open();
        command.ExecuteNonQuery();
    }
}