using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class GetAboutByIdQueryHandle
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery query)
    {
        var about = await _repository.GetByIdAsync(query.Id);
        var result = new List<GetAboutByIdQueryResult>();
        if (about != null)
        {
            result.Add(new GetAboutByIdQueryResult
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
