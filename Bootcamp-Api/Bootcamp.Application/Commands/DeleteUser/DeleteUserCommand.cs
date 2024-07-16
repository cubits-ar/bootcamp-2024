using MediatR;

namespace Bootcamp.Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public int UserId { get; set; }
}