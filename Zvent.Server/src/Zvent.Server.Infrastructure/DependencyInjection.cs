using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zvent.Server.Infrastructure.Authentication;
using Zvent.Server.Infrastructure.Persistance.Repositories;
using Zvent.Server.Usecase.Authentication;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddScoped<IUserRepository, UserDynamoDbRepository>();
        services.AddScoped<IEventsRepository, EventsDynamoDbRepository>();
        services.AddScoped<ITicketRepository, TicketDynamoDbRepository>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
