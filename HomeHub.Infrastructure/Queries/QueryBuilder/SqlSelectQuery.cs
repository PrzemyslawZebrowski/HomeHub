using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace HomeHub.Infrastructure.Queries.QueryBuilder;

public class SqlSelectQuery
{
    private readonly IDbConnection _dbConnection;
    private readonly DynamicParameters _parameters;
    private readonly string _query;

    public SqlSelectQuery(IDbConnection dbConnection, string query, DynamicParameters parameters)
    {
        _dbConnection = dbConnection;
        _query = query;
        _parameters = parameters;
    }

    public async Task<IEnumerable<T>> ExecuteToList<T>()
    {
        return await _dbConnection.QueryAsync<T>(_query, _parameters);
    }

    public async Task<T> ExecuteSingle<T>()
    {
        return await _dbConnection.QuerySingleAsync<T>(_query, _parameters);
    }

    public async Task<T> ExecuteSingleOrDefault<T>()
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<T>(_query, _parameters);
    }
}