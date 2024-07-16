using Bootcamp.Domain.Entities;

namespace Bootcamp.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetList();
    Task<User?> Get(int userId);
    Task Create(User user);
    Task Update(User user);
    Task Delete(User user);
}