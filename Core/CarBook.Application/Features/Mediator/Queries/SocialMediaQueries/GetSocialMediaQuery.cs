using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
public class GetSocialMediaQuery:IRequest<List<GetSocialMediaQueryResult>>
{
}
