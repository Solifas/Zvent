using Microsoft.EntityFrameworkCore;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Infrastructure.Persistance.Contexts;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Infrastructure.Persistance.Repositories;

public class EventsDynamoDbRepository : IEventsRepository
{
    //implement the missing members using the dynamodb repository refer to UserDynamoDbRepository.cs
    public Task<Event> CreateEvent(Event @event)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEvent(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Event?> GetEvent(Guid id)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Event> GetEvents(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<Event> UpdateEvent(Event @event)
    {
        throw new NotImplementedException();
    }
}
