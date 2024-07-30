namespace Bootcamp.Application.Models;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? RoleName { get; set; }
}