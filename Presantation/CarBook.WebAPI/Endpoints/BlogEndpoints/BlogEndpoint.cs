using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.BlogEndpoints
{
    public static class BlogEndpoint
    {
        public static void AppBlogEndpoint(this IEndpointRouteBuilder app)
        {
            var blog = app.MapGroup("/blog").WithTags("Blog");

            blog.MapPost(string.Empty, CreateBlogAsync);
            blog.MapPut(string.Empty, UpdateBlogAsync);
            blog.MapGet(string.Empty, GetBlogAsync);
            blog.MapGet("GetAuthorByBlogId", GetAuthorByBlogId);
            blog.MapGet("Lastest3ForPresantationPage", GetLastest3ForPresantationPageAsync);
            blog.MapGet("{id}", GetBlogByIdAsync);
            blog.MapDelete("{id}", RemoveBlogAsync);
        }

        private static async Task<IResult> GetLastest3ForPresantationPageAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetBlogLastest3ForPresantationPageQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetAuthorByBlogId(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetAuthorByBlogIdForBlogDetailPageQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> CreateBlogAsync(IMediator mediator, CreateBlogCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateBlogAsync(IMediator mediator, UpdateBlogCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetBlogAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetBlogQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetBlogByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetBlogByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveBlogAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveBlogCommand(id));
            return Results.Ok(response);
        }
    }
}
