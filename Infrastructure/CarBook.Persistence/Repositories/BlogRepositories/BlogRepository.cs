using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.BlogRepositories;

public class BlogRepository(CarBookContext context) : IBlogRepository
{
    public Task<List<Blog>> GetAllBlogsWithAuthorAndCategoryAsync()
    {
        return context.Blogs.Include(x => x.Author).Include(x => x.Category).ToListAsync();
    }

    public Task<Blog> GetByIdBlogsWithAuthorAndCategoryAsync(int Id)
    {
        return context.Blogs.Include(x => x.Author).Include(x => x.Category).Where(x => x.Id == Id).FirstOrDefaultAsync()!;
    }

    public async Task<List<Blog>> GetLast3BlogsWithRelationsAsync()
    {
        return await context.Blogs
        .Include(x => x.Author)
        .OrderByDescending(x => x.CreatedDate)
        .Take(3)
        .ToListAsync();
    }
}
