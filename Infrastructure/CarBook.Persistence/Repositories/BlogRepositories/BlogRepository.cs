using CarBook.Application.Features.Mediator.Results.BlogResults;
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
    public async Task<List<GetBlogCountByCategoryQueryResult>> GetBlogCountByCategoryAsync()
    {
        return await context.Blogs.Where(x => x.Category != null).GroupBy(x => x.Category!.Name).Select(x => new GetBlogCountByCategoryQueryResult
        {
            CategoryName = x.Key,
            BlogCount = x.Count()
        }).ToListAsync();
    }

    public async Task<List<Blog>> GetLast5BlogsWithRelationsAsync()
    {
        return await context.Blogs
       .Include(x => x.Author)
       .OrderByDescending(x => x.CreatedDate)
       .Take(5)
       .ToListAsync();
    }

    public Task<List<GetBlogsByCategoryIdQueryResult>> GetBlogsByCategoryIdAsync(int Id)
    {
        return context.Blogs.Where(x => x.CategoryId == Id).Select(x => new GetBlogsByCategoryIdQueryResult
        {
            Title = x.Title,
            Description = x.Description,
            AuthorName = x.Author!.Name,
            CategoryName = x.Category!.Name,
            CoverImageUrl = x.CoverImageUrl,
            CreatedDate = x.CreatedDate,
        }).ToListAsync();
    }
}
