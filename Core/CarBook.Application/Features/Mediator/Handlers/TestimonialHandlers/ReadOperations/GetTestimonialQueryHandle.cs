using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.ReadOperations;

public class GetTestimonialQueryHandle(IRepository<Testimonial> repository, IMapper mapper)
    : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
{
    public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<GetTestimonialQueryResult>>(await repository.GetAllAsync());
    }
}
