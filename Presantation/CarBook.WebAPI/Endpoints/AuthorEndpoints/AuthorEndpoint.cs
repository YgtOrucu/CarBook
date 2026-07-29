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

            author.MapPost(string.Empty, CreateAuthorAsync);
            author.MapPut(string.Empty, UpdateAuthorAsync);
            author.MapGet(string.Empty, GetAuthorAsync);
            author.MapGet("{id}", GetAuthorByIdAsync);
            author.MapDelete("{id}", RemoveAuthorAsync);
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
