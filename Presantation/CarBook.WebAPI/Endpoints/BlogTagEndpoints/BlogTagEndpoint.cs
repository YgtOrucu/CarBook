using CarBook.Application.Features.Mediator.Queries.BlogTagQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.BlogTagEndpoints
{
    public static class BlogTagEndpoint
    {
        public static void AppBlogTagEndpoint(this IEndpointRouteBuilder app)
        {
            var BlogTag = app.MapGroup("/blogTag").WithTags("BlogTag");

            //BlogTag.MapPost(string.Empty, CreateBlogTagAsync);
            //BlogTag.MapPut(string.Empty, UpdateBlogTagAsync);
            //BlogTag.MapGet(string.Empty, GetBlogTagAsync);
            BlogTag.MapGet("GetTag4Piece", GetTag4PieceForBlogDetailPageAsync);
            BlogTag.MapGet("GetTagAll", GetTagAllForBlogDetailPageAsync);
            //BlogTag.MapDelete("{id}", RemoveBlogTagAsync);
        }


        //private static async Task<IResult> CreateBlogTagAsync(IMediator mediator, CreateBlogTagCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> UpdateBlogTagAsync(IMediator mediator, UpdateBlogTagCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> GetBlogTagAsync(IMediator mediator)
        //{
        //    var response = await mediator.Send(new GetBlogTagQuery());
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        private static async Task<IResult> GetTag4PieceForBlogDetailPageAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetTag4PieceForBlogDetailPageQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetTagAllForBlogDetailPageAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetTagAllForBlogDetailPageQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        //private static async Task<IResult> RemoveBlogTagAsync(int id, IMediator mediator)
        //{
        //    var response = await mediator.Send(new RemoveBlogTagCommand(id));
        //    return Results.Ok(response);
        //}
    }
}
