using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Vacaciones.Datos.Data;

public class VacacionesDbConnection
{
    private readonly string _connectionString;

    /// <summary>
    /// Constructor que inicializa la cadena de conexión desde IConfiguration.
    /// </summary>
    /// <param name="configuration">Instancia de IConfiguration para leer la configuración.</param>
    public VacacionesDbConnection(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("No se encontro la cadena de conexión");

    /// <summary>
    /// Obtiene una conexión a la base de datos.
    /// </summary>
    /// <returns>Una conexión IDbConnection.</returns>
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    /// <summary>
    /// Prueba la conexión a la base de datos.
    /// </summary>
    /// <returns>True si la conexión fue exitosa; de lo contrario, false.</returns>
    public bool TestConnection()
    {
        try
        {
            using var connection = GetConnection();
            connection.Open();
            Console.WriteLine("Conexión exitosa.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            return false;
        }
    }
}