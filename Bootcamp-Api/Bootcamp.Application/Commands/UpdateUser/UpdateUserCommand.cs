using MediatR;

namespace Bootcamp.Application.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;
}