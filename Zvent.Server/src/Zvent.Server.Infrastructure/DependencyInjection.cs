using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zvent.Server.Infrastructure.Persistance.Repositories;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IUserRepository, UserDynamoDbRepository>();
        services.AddScoped<IEventsRepository, EventsDynamoDbRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();

        services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(RegionEndpoint.EUWest1));
        // services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        // services.AddScoped<IJwtService, JwtService>();
        // services.AddScoped<IPasswordService, PasswordService>();

        return services;
    }
}
