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

            comments.MapGet("", GetCommentAsync).AllowAnonymous();
            comments.MapGet("{id}", GetCommentByIdAsync).AllowAnonymous();
            comments.MapGet("GetCommentByBlogId", GetCommentByBlogIdAsync).AllowAnonymous();
            comments.MapGet("GetCommentWithBlogTitle", GetCommentWithBlogTitleAsync).AllowAnonymous();
            comments.MapPost("", CreateCommentAsync).RequireAuthorization();
            comments.MapGet("GetLoginUsersComments/{userEmail}", GetLoginUsersCommentAsync).RequireAuthorization();
            comments.MapDelete("DeleteCommentForUser/{Id}", DeleteCommentForUserAsync).RequireAuthorization();
            comments.MapPut("UpdateCommentForUser", UpdateCommentForUserAsync).RequireAuthorization();


            var adminComment = comments.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminComment.MapPut("", UpdateCommentAsync);
            adminComment.MapDelete("{id}", RemoveCommentAsync);
        }

        private static async Task<IResult> GetLoginUsersCommentAsync(string userEmail, IMediator mediator)
        {
            var response = await mediator.Send(new GetLoginUsersCommentQuery(userEmail));
            return response != null ? Results.Ok(response) : Results.NotFound("Kullanıcıya ait yorum bulunamadı.");
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
        private static async Task<IResult> GetCommentWithBlogTitleAsync(IMediator mediator)
        {
            var result = await mediator.Send(new GetCommentWithBlogTitleQuery());
            return result != null ? Results.Ok(result) : Results.NotFound();
        }


        private static async Task<IResult> CreateCommentAsync(IMediator mediator, CreateCommentCommand command)
        {
            await mediator.Send(command);
            return Results.Ok("Comment is succesfully added");
        }

        private static async Task<IResult> UpdateCommentForUserAsync(IMediator mediator, UpdateCommentForUserCommand command)
        {
            var result = await mediator.Send(command);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        public static async Task<IResult> DeleteCommentForUserAsync(int Id, IMediator mediator)
        {
            await mediator.Send(new RemoveCommentCommand(Id));
            return Results.Ok("Comment is succesfully deleted.");
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
