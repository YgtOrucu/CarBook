using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces;
public interface IBlogRepository
{
    Task<List<Blog>> GetAllBlogsWithAuthorAndCategoryAsync();
    Task<Blog> GetByIdBlogsWithAuthorAndCategoryAsync(int Id);
    Task<List<Blog>> GetLast3BlogsWithRelationsAsync();
    Task<List<Blog>> GetLast5BlogsWithRelationsAsync();
    Task<List<GetBlogCountByCategoryQueryResult>> GetBlogCountByCategoryAsync();
}
