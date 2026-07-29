using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public record GetBlogByIdQuery(int Id) : IRequest<GetBlogByIdQueryResult>;
