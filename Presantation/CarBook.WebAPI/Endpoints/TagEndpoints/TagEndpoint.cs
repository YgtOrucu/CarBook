using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.TagEndpoints
{
    public static class TagEndpoint
    {
        public static void AppTagEndpoint(this IEndpointRouteBuilder app)
        {
            var Tag = app.MapGroup("/tag").WithTags("Tag");

            Tag.MapGet("", GetTagAsync).AllowAnonymous();
            Tag.MapGet("{id}", GetTagByIdAsync).AllowAnonymous();

            var adminTag = Tag.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminTag.MapPost("", CreateTagAsync);
            adminTag.MapPut("", UpdateTagAsync);
            adminTag.MapDelete("{id}", RemoveTagAsync);
        }


        private static async Task<IResult> CreateTagAsync(IMediator mediator, CreateTagCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateTagAsync(IMediator mediator, UpdateTagCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetTagAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetTagQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetTagByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetTagByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveTagAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveTagCommand(id));
            return Results.Ok(response);
        }
    }
}
