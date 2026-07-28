using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServicesQueries;

public record GetServicesLastest5Query : IRequest<List<GetServicesLastest5QueryResult>>;
