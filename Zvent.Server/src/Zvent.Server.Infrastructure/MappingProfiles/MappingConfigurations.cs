using AutoMapper;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Queries.GetUser;
using Zvent.Server.Usecase.Queries.GetEventById;
using Zvent.Server.Usecase.Commands.Registration;
using Zvent.Server.Usecase.Commands.RegisterEvent;
using Zvent.Server.Usecase.Commands.GenerateTicket;
using Zvent.Server.Domain.DTOs;

namespace Zvent.Server.Infrastructure.MappingProfiles;

public class MappingConfigurations : Profile
{
    public MappingConfigurations()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<RegisterUserCommand, User>().ReverseMap();
        CreateMap<RegisterEventCommand, Event>().ReverseMap();
        CreateMap<GenerateTicketCommand, Ticket>().ReverseMap();
        CreateMap<GetUserQuery, User>().ReverseMap();
        CreateMap<EventByIdResponse, Event>().ReverseMap();
    }
}