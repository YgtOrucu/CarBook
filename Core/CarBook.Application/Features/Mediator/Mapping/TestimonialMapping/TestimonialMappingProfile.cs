using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.TestimonialMapping;

public class TestimonialMappingProfile : Profile
{
    public TestimonialMappingProfile()
    {
        CreateMap<CreateTestimonialCommand, Testimonial>();
        CreateMap<UpdateTestimonialCommand, Testimonial>();
        CreateMap<Testimonial, GetTestimonialQueryResult>();
        CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
    }
}
