using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.ReadOperations;

public class GetSocialMediaQueryHandle(IRepository<SocialMedia> repository, IMapper mapper)
    : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
{
    public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<GetSocialMediaByIdQueryResult>(await repository.GetByIdAsync(request.Id));
        return values;
    }
}
