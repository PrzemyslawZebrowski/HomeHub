using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Domain.Common;

namespace HomeHub.Application.Abstraction.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);

    void Delete(T entity);

    Task<T> GetAsync(long id, CancellationToken cancellationToken);

    Task<T> GetWithSpecifiedDependenciesAsync(long id, List<Expression<Func<T, object>>> includes, CancellationToken cancellationToken);

    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
}