using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServicesQueries;

public record GetServicesByIdQuery(int Id) : IRequest<GetServicesByIdQueryResult>;
