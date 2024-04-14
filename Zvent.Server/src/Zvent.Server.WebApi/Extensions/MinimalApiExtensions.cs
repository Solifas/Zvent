using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zvent.Server.WebApi.Endpoints;

namespace Zvent.Server.WebApi.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        IEnumerable<IUserEndpointDefinition> endpointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IUserEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IUserEndpointDefinition>();

        foreach (var endpointDef in endpointDefinitions)
        {
            endpointDef.RegisterEndpoints(app);
        }
    }
}
