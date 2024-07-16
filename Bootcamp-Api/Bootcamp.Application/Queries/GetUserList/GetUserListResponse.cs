using Bootcamp.Application.Models;

namespace Bootcamp.Application.Queries.GetUserList;

public class GetUserListResponse
{
    public List<UserDto> UserList { get; set; } = [];
}