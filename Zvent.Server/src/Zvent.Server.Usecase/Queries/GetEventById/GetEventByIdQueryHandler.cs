using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Queries.GetEventById;

public class GetEventByIdQueryHandler(IEventsRepository eventsRepository, IMapper mapper) : IRequestHandler<GetEventByIdQuery, EventByIdResponse>
{
    public async Task<EventByIdResponse> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var validation = new GetEventByIdQueryValidator().Validate(request);
        if (!validation.IsValid)
        {
            var errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
            var errorMessage = string.Join(", ", errors);
            throw new ValidationException(errorMessage);
        }
        var eventEntity = await eventsRepository.GetEvent(request.Id) ?? throw new Exception("Event not found");
        var response = mapper.Map<EventByIdResponse>(eventEntity);
        return response;
    }
}
