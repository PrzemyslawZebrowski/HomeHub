using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Domain.Entities.Users;

namespace HomeHub.Application.Abstraction.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetAsync(string id, CancellationToken cancellationToken);
    Task<User> GetWithSpecifiedDependenciesAsync(string id, List<Expression<Func<User, object>>> includes, CancellationToken cancellationToken);
}