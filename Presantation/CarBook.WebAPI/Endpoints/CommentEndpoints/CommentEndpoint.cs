using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.CommentEndpoints
{
    public static class CommentEndpoint
    {
        public static void AppCommentEndpoint(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comment").WithTags("Comments");

            comments.MapGet(string.Empty, GetCommentAsync);
            comments.MapGet("{id}", GetCommentByIdAsync);
            comments.MapGet("GetCommentByBlogId", GetCommentByBlogIdAsync);
            comments.MapPost(string.Empty, CreateCommentAsync);
            comments.MapPut(string.Empty, UpdateCommentAsync);
            comments.MapDelete("{id}", RemoveCommentAsync);
        }

        private static async Task<IResult> GetCommentAsync(IMediator mediator)
        {
            var result = await mediator.Send(new GetCommentQuery());
            return result != null ? Results.Ok(result) : Results.BadRequest("The Comment listing process failed.");
        }

        private static async Task<IResult> GetCommentByIdAsync(int id, IMediator mediator)
        {
            var result = await mediator.Send(new GetCommentByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> GetCommentByBlogIdAsync(int BlogId, IMediator mediator)
        {
            var result = await mediator.Send(new GetCommentByBlogIdQuery(BlogId));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> CreateCommentAsync(IMediator mediator, CreateCommentCommand command)
        {
            await mediator.Send(command);
            return Results.Ok("Comment is succesfully added");
        }

        private static async Task<IResult> UpdateCommentAsync(IMediator mediator, UpdateCommentCommand command)
        {
            await mediator.Send(command);

            return Results.Ok("Comment is succesfully updated.");
        }

        public static async Task<IResult> RemoveCommentAsync(int id, IMediator mediator)
        {
            await mediator.Send(new RemoveCommentCommand(id));
            return Results.Ok("Comment is succesfully deleted.");
        }
    }
}
