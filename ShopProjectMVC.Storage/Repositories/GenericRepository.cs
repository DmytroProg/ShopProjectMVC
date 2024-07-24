using Microsoft.EntityFrameworkCore;
using ShopProjectMVC.Core.Interfaces;

namespace ShopProjectMVC.Storage.Repositories;

public class GenericRepository : IRepository
{
    private readonly ShopProjectContext _context;

    public GenericRepository(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ShopProjectContext>()
            .UseSqlServer(connectionString)
            .Options;
        _context = new ShopProjectContext(options);
    }

    public Task<T> Add<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public Task Delete<T>(int id) where T : class
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }

    public Task<T> GetById<T>(int id) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<T> Update<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }
}
