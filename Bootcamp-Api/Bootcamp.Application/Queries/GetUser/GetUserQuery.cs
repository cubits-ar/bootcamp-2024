using MediatR;

namespace Bootcamp.Application.Queries.GetUser;

public class GetUserQuery : IRequest<GetUserResponse>
{
    public int UserId { get; set; }
}