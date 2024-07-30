using Bootcamp.Domain.Entities;
using System.Linq.Expressions;

namespace Bootcamp.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetList();
    Task<List<User>> GetList(Expression<Func<User, bool>> predicate);
    Task<User?> Get(int userId);
    Task<int> Create(User user);
    Task Update(User user);
    Task Delete(User user);
}