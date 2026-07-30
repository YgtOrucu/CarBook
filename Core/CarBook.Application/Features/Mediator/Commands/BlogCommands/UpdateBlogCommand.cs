using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public class UpdateBlogCommand : IRequest<object>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string Description { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
}
