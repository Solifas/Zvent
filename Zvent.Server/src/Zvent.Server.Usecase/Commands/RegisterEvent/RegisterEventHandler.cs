using AutoMapper;
using MediatR;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Commands.RegisterEvent;

public class RegisterEventHandler(IMapper mapper, IEventsRepository eventsRepository) : IRequestHandler<RegisterEventCommand, RegisterEventResponse>
{
    public async Task<RegisterEventResponse> Handle(RegisterEventCommand request, CancellationToken cancellationToken)
    {
        var @event = mapper.Map<Event>(request);
        var createdEvent = await eventsRepository.CreateEvent(@event);

        return new RegisterEventResponse
        {
            Id = createdEvent.Id
        };
    }
}
