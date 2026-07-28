using System.Linq.Expressions;

namespace CarBook.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetFilterAsync(Expression<Func<T, bool>> filter);
    IQueryable<T> GetByQuery();
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}