using MediatR;
using FluentValidation;

namespace Zvent.Server.Usecase.Commands.Registration;

public class RegisterUserCommand : IRequest<RegisterUserResponse>
{
    public string? Email { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
}

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Password).MinimumLength(8).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
    }
}

public class RegisterUserResponse
{
    public required string Name { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string? Token { get; set; }
}
