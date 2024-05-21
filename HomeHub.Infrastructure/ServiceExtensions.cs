using System;
using System.Data;
using Azure.Storage.Blobs;
using HomeHub.Application.Abstraction.Providers;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Constants;
using HomeHub.Infrastructure.BlobStorage.Services;
using HomeHub.Infrastructure.Context;
using HomeHub.Infrastructure.Providers;
using HomeHub.Infrastructure.Queries;
using HomeHub.Infrastructure.Queries.QueryBuilder;
using HomeHub.Infrastructure.Repositories;
using HomeHub.Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeHub.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<HomeHubContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("HomeHubDatabase")));

        serviceCollection.AddScoped<IDbConnection>(
            _ => new SqlConnection(configuration.GetConnectionString("HomeHubDatabase")));

        serviceCollection.AddTransient<SqlSelectQueryBuilder>();

        serviceCollection.AddMemoryCache();

        serviceCollection.AddSingleton<ICurrencyService, CurrencyService>();
        serviceCollection.AddHttpClient(HttpClientsNames.NbpApi, client =>
        {
            client.BaseAddress = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/");
        });

        serviceCollection.RegisterQueries();
        serviceCollection.RegisterRepositories();
        serviceCollection.RegisterServices();
        serviceCollection.RegisterAzureStorage(configuration);
    }

    public static void RegisterQueries(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserQuery, UserQuery>();
        serviceCollection.AddScoped<ILookupQuery, LookupQuery>();
        serviceCollection.AddScoped<IAnnouncementQuery, AnnouncementQuery>();
    }

    public static void RegisterRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
    }

    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
        serviceCollection.AddScoped<IAnnouncementPhotoService, AnnouncementPhotoService>();
    }

    public static void RegisterAzureStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton(
            _ => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));

        serviceCollection.AddScoped<IBlobService, BlobService>();
    }
}