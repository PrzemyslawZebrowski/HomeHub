using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Domain.Entities.Users;
using HomeHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly HomeHubContext _context;

    public UserRepository(HomeHubContext context) : base(context)
    {
        _context = context;
    }

    public Task<User> GetAsync(string id, CancellationToken cancellationToken)
    {
        return _context.Set<User>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public Task<User> GetWithSpecifiedDependenciesAsync(string id, List<Expression<Func<User, object>>> includes,
        CancellationToken cancellationToken)
    {
        var queryable = _context.Set<User>().AsQueryable();

        if (includes.Any())
        {
            queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
        }

        return queryable
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }
}