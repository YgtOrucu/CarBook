using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistence.Repositories;

public class GenericRepository<T>(CarBookContext _carBook) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbset = _carBook.Set<T>();
    public async Task CreateAsync(T entity)
    {
        await _dbset.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbset.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbset.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbset.FindAsync(id);
    }

    public IQueryable<T> GetByQuery()
    {
        return _dbset;
    }

    public async Task<T> GetFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbset.FirstOrDefaultAsync(filter);
    }

    public void Update(T entity)
    {
        _dbset.Update(entity);
    }
}
