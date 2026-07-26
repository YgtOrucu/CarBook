using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries;

public record GetTestimonialByIdQuery(int Id) : IRequest<GetTestimonialByIdQueryResult>;
