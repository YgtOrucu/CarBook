using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class CreateBlogCommand : IRequest<object>
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string Description { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
}
