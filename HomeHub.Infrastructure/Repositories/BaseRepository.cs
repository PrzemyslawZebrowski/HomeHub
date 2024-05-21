using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Domain.Common;
using HomeHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly HomeHubContext _context;

    protected BaseRepository(HomeHubContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public Task<T> GetAsync(long id, CancellationToken cancellationToken)
    {
        return _context.Set<T>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public Task<T> GetWithSpecifiedDependenciesAsync(long id, List<Expression<Func<T, object>>> includes, CancellationToken cancellationToken)
    {
        var queryable = _context.Set<T>().AsQueryable();

        if (includes.Any())
        {
            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
        }

        return queryable
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _context.Set<T>()
            .ToListAsync(cancellationToken);
    }
}