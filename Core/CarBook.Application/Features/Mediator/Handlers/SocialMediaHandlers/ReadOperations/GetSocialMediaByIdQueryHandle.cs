using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.ReadOperations;
public class GetSocialMediaByIdQueryHandle(IRepository<SocialMedia> repository, IMapper mapper)
    : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<List<GetSocialMediaQueryResult>>(await repository.GetAllAsync());
        return value;
    }
}
