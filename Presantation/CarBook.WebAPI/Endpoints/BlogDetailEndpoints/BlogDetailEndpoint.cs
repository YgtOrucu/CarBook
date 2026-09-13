using CarBook.Application.Features.Mediator.Queries.BlogDetailQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.BlogDetailEndpoints
{
    public static class BlogDetailEndpoint
    {
        public static void AppBlogDetailEndpoint(this IEndpointRouteBuilder app)
        {
            var blogDetail = app.MapGroup("/blogDetail").WithTags("BlogDetail").AllowAnonymous();

            blogDetail.MapGet("{id}", GetBlogDetailByIdAsync);   
        }

        private static async Task<IResult> GetBlogDetailByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetBlogDetailsByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }
    }
}
