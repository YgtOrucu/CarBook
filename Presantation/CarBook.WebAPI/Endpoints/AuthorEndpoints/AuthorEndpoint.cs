using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.AuthorEndpoints
{
    public static class AuthorEndpoint
    {
        public static void AppAuthorEndpoint(this IEndpointRouteBuilder app)
        {
            var author = app.MapGroup("/author").WithTags("Author");

            author.MapPost("", CreateAuthorAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));
            author.MapPut("", UpdateAuthorAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));
            author.MapGet("", GetAuthorAsync).AllowAnonymous();
            author.MapGet("{id}", GetAuthorByIdAsync).AllowAnonymous();
            author.MapDelete("{id}", RemoveAuthorAsync).RequireAuthorization(policy => policy.RequireRole("Admin"));
        }


        private static async Task<IResult> CreateAuthorAsync(IMediator mediator, CreateAuthorCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateAuthorAsync(IMediator mediator, UpdateAuthorCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetAuthorAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetAuthorQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetAuthorByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetAuthorByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveAuthorAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveAuthorCommand(id));
            return Results.Ok(response);
        }
    }
}
