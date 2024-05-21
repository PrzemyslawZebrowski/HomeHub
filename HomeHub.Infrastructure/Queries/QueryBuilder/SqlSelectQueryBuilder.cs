using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using HomeHub.Application.Common.Model;

namespace HomeHub.Infrastructure.Queries.QueryBuilder;

public class SqlSelectQueryBuilder
{
    private readonly IDbConnection _dbConnection;
    private readonly List<string> _columns = new();
    private string _tableName = string.Empty;
    private DynamicParameters _parameters = new();
    private readonly List<string> _conditions = new();
    private readonly List<string> _orderBy = new();

    public SqlSelectQueryBuilder(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public SqlSelectQueryBuilder SelectAllProperties<T>(params string[] skipColumns)
    {
        _columns.AddRange(typeof(T).GetProperties().Select(p => p.Name).Where(n => !skipColumns.Contains(n)));

        return this;
    }

    public SqlSelectQueryBuilder Select(params string[] columns)
    {
        _columns.AddRange(columns);

        return this;
    }

    public SqlSelectQueryBuilder From(string tableName)
    {
        _tableName = tableName;

        return this;
    }

    public SqlSelectQueryBuilder Where(string condition, object parameters)
    {
        _conditions.Add(condition);
        _parameters.AddDynamicParams(parameters);

        return this;
    }

    public SqlSelectQueryBuilder OrderBy(string orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
        {
            return this;
        }

        _orderBy.Add(orderBy);

        return this;
    }

    public SqlSelectQuery Build()
    {
        if (string.IsNullOrWhiteSpace(_tableName))
        {
            throw new InvalidOperationException("Table name cannot be null or empty.");
        }

        var queryBuilder = new StringBuilder();

        queryBuilder.Append("SELECT ");
        queryBuilder.Append(string.Join(", ", _columns));

        queryBuilder.Append($" FROM {_tableName}");

        if (_conditions.Any())
        {
            queryBuilder.Append(" WHERE ");
            queryBuilder.Append(string.Join(" AND ", _conditions));
        }

        if (_orderBy.Any())
        {
            queryBuilder.Append(" ORDER BY ");
            queryBuilder.Append(string.Join(", ", _orderBy));
        }

        var query = new SqlSelectQuery(_dbConnection, queryBuilder.ToString(), _parameters);

        Reset();

        return query;
    }

    public SqlSelectPagedQuery BuildPagedQuery(PaginationCriteria paginationCriteria)
    {
        if (string.IsNullOrWhiteSpace(_tableName))
        {
            throw new InvalidOperationException("Table name cannot be null or empty.");
        }

        if (!_orderBy.Contains("CreatedOn DESC"))
        {
            _orderBy.Add("CreatedOn DESC");
        }

        var queryBuilder = new StringBuilder();
        var countQueryBuilder = new StringBuilder();

        queryBuilder.Append("SELECT ");
        queryBuilder.Append(string.Join(", ", _columns));
        queryBuilder.Append($" FROM {_tableName}");

        countQueryBuilder.Append("SELECT ");
        countQueryBuilder.Append("Count(*)");
        countQueryBuilder.Append($" FROM {_tableName}");

        if (_conditions.Any())
        {
            queryBuilder.Append(" WHERE ");
            queryBuilder.Append(string.Join(" AND ", _conditions));

            countQueryBuilder.Append(" WHERE ");
            countQueryBuilder.Append(string.Join(" AND ", _conditions));
        }

        if (_orderBy.Any())
        {
            queryBuilder.Append(" ORDER BY ");
            queryBuilder.Append(string.Join(", ", _orderBy));
        }

        var offset = (paginationCriteria.PageNumber - 1) * paginationCriteria.PageSize;
        queryBuilder.Append($" OFFSET {offset} ROWS FETCH NEXT {paginationCriteria.PageSize} ROWS ONLY");

        var query = new SqlSelectPagedQuery(
            _dbConnection,
            queryBuilder.ToString(),
            countQueryBuilder.ToString(),
            _parameters,
            paginationCriteria);

        Reset();

        return query;
    }

    private void Reset()
    {
        _columns.Clear();
        _tableName = string.Empty;
        _conditions.Clear();
        _parameters = new();
        _orderBy.Clear();
    }
}