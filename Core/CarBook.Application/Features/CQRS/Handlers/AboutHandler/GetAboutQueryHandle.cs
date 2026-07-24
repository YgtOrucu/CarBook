using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class GetAboutQueryHandle
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var abouts = await _repository.GetAllAsync();
        var result = new List<GetAboutQueryResult>();
        foreach (var about in abouts)
        {
            result.Add(new GetAboutQueryResult
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl,
                CreatedDate = about.CreatedDate,
                DeletedDate = about.DeletedDate,
                UpdatedDate = about.UpdatedDate,
                IsDeleted = about.IsDeleted
            });
        }
        return result;
    }
}
