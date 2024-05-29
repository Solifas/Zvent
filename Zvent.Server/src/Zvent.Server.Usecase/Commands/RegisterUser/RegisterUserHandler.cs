using MediatR;
using AutoMapper;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Authentication;
using Zvent.Server.Usecase.Commands.Registration;
using Zvent.Server.Usecase.Persistance.Interfaces;
using System.Security.Claims;

namespace Zvent.Server.Usecase.Commands.RegisterUser;

public class RegistrationHandler(IMapper mapper, IUserRepository userRepository,
 IJwtTokenGenerator tokenGenerator, IUserClaimsService userClaimsService) : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);

        bool isUserCreated = await userRepository.CreateUser(user);
        if (!isUserCreated) return new RegisterUserResponse
        {
            ErrorMessage = "User already exists or there was an error creating the user.",
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        var token = tokenGenerator.GenerateToken(request.Name, request.Email);

        userClaimsService.SetClaim(ClaimTypes.Name, request.Name);
        userClaimsService.SetClaim(ClaimTypes.Email, request.Email);
        userClaimsService.SetClaim(ClaimTypes.MobilePhone, request.PhoneNumber);

        return new RegisterUserResponse
        {
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Token = token
        };
    }
}