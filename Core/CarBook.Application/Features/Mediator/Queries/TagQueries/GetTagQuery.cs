using CarBook.Application.Features.Mediator.Results.TagResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagQueries;

public record GetTagQuery : IRequest<List<GetTagQueryResult>>;

