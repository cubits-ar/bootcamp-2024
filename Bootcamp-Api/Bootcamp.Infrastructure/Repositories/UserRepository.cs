using Bootcamp.Domain.Entities;
using Bootcamp.Domain.Interfaces;
using Bootcamp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bootcamp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SqlServerDbContext _dbContext;

    public UserRepository(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetList()
    {
        return await _dbContext
            .Set<User>()
            .Include(x => x.Role)
            .ToListAsync();
    }

    public async Task<List<User>> GetList(Expression<Func<User, bool>> predicate)
    {
        return await _dbContext
            .Set<User>()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<User?> Get(int userId)
    {
        return await _dbContext
            .Set<User>()
            .Include(x => x.Role)
            .Where(user => user.Id == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<int> Create(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return user.Id; // Just for test cases only
    }

    public async Task Update(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}