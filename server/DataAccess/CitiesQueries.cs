using Dapper;

namespace DataAccess;

public class CitiesQueries
{
    private readonly ConnectionManager _connectionManager;

    public CitiesQueries(ConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
    }

    public async Task<IEnumerable<dynamic>> GetCitiesList()
    {
        const string sql = "SELECT * FROM US_CITIES;";
        return await _connectionManager.Connection.QueryAsync(sql);
    }
}