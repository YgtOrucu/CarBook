using CarBook.Application.Features.Mediator.Results.ServicesResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServicesQueries;

public class GetServicesQuery : IRequest<List<GetServicesQueryResult>> { }
