using Bootcamp.Application.Commands.CreateUser;
using Bootcamp.Application.Commands.DeleteUser;
using Bootcamp.Application.Commands.UpdateUser;
using Bootcamp.Application.Queries.GetUser;
using Bootcamp.Application.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
[Consumes("application/json")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetList()
    {
        var response = await _mediator.Send(new GetUserListQuery());
        return Ok(response);
    }

    [HttpGet]
    [Route("{userId:int}")]
    public async Task<IActionResult> Get([FromRoute] int userId)
    {
        var response = await _mediator.Send(new GetUserQuery { UserId = userId });
        return Ok(response);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    [Route("{userId:int}")]
    public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserCommand command)
    {
        command.UserId = userId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete]
    [Route("{userId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int userId)
    {
        var command = new DeleteUserCommand { UserId = userId };
        await _mediator.Send(command);
        return Ok();
    }
}