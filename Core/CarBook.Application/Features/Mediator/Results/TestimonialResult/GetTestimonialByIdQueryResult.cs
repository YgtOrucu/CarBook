using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.TestimonialResult;
public class GetTestimonialByIdQueryResult : AuditableDto
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
}
