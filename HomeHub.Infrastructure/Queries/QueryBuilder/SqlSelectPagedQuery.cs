using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HomeHub.Application.Common.Model;

namespace HomeHub.Infrastructure.Queries.QueryBuilder;

public class SqlSelectPagedQuery
{
    private readonly IDbConnection _dbConnection;
    private readonly string _query;
    private readonly string _countQuery;
    private readonly DynamicParameters _parameters;
    private readonly PaginationCriteria _paginationCriteria;

    public SqlSelectPagedQuery(IDbConnection dbConnection, string query, string countQuery, DynamicParameters parameters, PaginationCriteria paginationCriteria)
    {
        _dbConnection = dbConnection;
        _query = query;
        _countQuery = countQuery;
        _parameters = parameters;
        _paginationCriteria = paginationCriteria;
    }

    public async Task<PageDTO<T>> ExecuteToPage<T>()
    {
        var result = await _dbConnection.QueryMultipleAsync(string.Concat(_query, Environment.NewLine, _countQuery), _parameters);

        return new PageDTO<T>(
            result.Read<T>().ToList(),
            _paginationCriteria.PageSize,
            _paginationCriteria.PageNumber,
            result.ReadFirst<int>());
    }
}