using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries;

public record GetAuthorQuery : IRequest<List<GetAuthorQueryResult>>;
