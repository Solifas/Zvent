using MediatR;
using AutoMapper;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Usecase.Commands.Registration;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Commands.RegisterUser;

public class RegistrationHandler(IMapper mapper, IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = mapper.Map<User>(request);

            var createdUser = await userRepository.CreateUser(user);

            return new RegisterUserResponse
            {
                Token = "token"
            };
        }
        catch (System.Exception ex)
        {

            throw;
        }
    }
}