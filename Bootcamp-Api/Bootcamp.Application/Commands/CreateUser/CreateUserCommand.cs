using MediatR;

namespace Bootcamp.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest
{
    public string Name { get; set; } = null!;
}