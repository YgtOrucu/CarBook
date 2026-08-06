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

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var about = await _repository.GetByIdAsync(query.Id);

        var result = new GetAboutByIdQueryResult
        {
            Id = about.Id,
            Title = about.Title,
            ImageUrl = about.ImageUrl,
            Description = about.Description,
            CreatedDate = about.CreatedDate,
            UpdatedDate = about.UpdatedDate,
            DeletedDate = about.DeletedDate,
            IsDeleted = about.IsDeleted
        };
       
        return result;
    }
}
