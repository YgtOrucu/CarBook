using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.ReadOperations;

public class GetTestimonialByIdQueryHandle(IRepository<Testimonial> repository, IMapper mapper)
    : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
{
    public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetTestimonialByIdQueryResult>(await repository.GetByIdAsync(request.Id));
    }
}
