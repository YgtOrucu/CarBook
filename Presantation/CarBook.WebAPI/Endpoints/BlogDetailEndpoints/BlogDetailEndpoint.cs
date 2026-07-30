using CarBook.Application.Features.Mediator.Queries.BlogDetailQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.BlogDetailEndpoints
{
    public static class BlogDetailEndpoint
    {
        public static void AppBlogDetailEndpoint(this IEndpointRouteBuilder app)
        {
            var blogDetail = app.MapGroup("/blogDetail").WithTags("BlogDetail");

            //blogDetail.MapPost(string.Empty, CreateBlogDetailAsync);
            //blogDetail.MapPut(string.Empty, UpdateBlogDetailAsync);
            //blogDetail.MapGet(string.Empty, GetBlogDetailAsync);
            blogDetail.MapGet("{id}", GetBlogDetailByIdAsync);
            //blogDetail.MapDelete("{id}", RemoveBlogDetailAsync);
        }

        //private static async Task<IResult> CreateBlogDetailAsync(IMediator mediator, CreateBlogDetailCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> UpdateBlogDetailAsync(IMediator mediator, UpdateBlogDetailCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> GetBlogDetailAsync(IMediator mediator)
        //{
        //    var response = await mediator.Send(new GetBlogDetailQuery());
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        private static async Task<IResult> GetBlogDetailByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetBlogDetailsByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        //private static async Task<IResult> RemoveBlogDetailAsync(int id, IMediator mediator)
        //{
        //    var response = await mediator.Send(new RemoveBlogDetailCommand(id));
        //    return Results.Ok(response);
        //}
    }
}
