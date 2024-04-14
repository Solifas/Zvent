using AutoMapper;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Commands.GenerateTicket;
using Zvent.Server.Usecase.Commands.RegisterEvent;
using Zvent.Server.Usecase.Commands.Registration;
namespace Zvent.Server.Infrastructure.MappingProfiles;

public class MappingConfigurations : Profile
{
    public MappingConfigurations()
    {
        CreateMap<RegisterUserCommand, User>();
        CreateMap<RegisterEventCommand, Event>();
        CreateMap<GenerateTicketCommand, Ticket>();
    }
}
