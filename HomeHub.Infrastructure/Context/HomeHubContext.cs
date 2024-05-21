using System.Reflection;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Infrastructure.Context;

public class HomeHubContext : DbContext
{
    public HomeHubContext(DbContextOptions<HomeHubContext> option) : base(option)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Announcement> Announcements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}