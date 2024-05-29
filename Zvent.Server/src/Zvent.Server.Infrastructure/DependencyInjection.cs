using Amazon.DynamoDBv2;
using Zvent.Server.Usecase.Encryption;
using Microsoft.Extensions.Configuration;
using Zvent.Server.Usecase.Authentication;
using Zvent.Server.Infrastructure.Encryption;
using Microsoft.Extensions.DependencyInjection;
using Zvent.Server.Infrastructure.Authentication;
using Zvent.Server.Usecase.Persistance.Interfaces;
using Zvent.Server.Infrastructure.Persistance.Repositories;

namespace Zvent.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddScoped<IUserClaimsService, UserClaimsService>();
        services.AddScoped<IUserRepository, UserDynamoDbRepository>();
        services.AddScoped<IEncryptionService, EncryptionService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IEventsRepository, EventsDynamoDbRepository>();
        services.AddScoped<ITicketRepository, TicketDynamoDbRepository>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
