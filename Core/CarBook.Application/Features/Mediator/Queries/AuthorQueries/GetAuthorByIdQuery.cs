using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries;
public record GetAuthorByIdQuery(int Id) : IRequest<GetAuthorByIdQueryResult>;
