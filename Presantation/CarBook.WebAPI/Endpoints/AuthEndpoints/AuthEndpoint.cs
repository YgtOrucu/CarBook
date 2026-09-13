using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Application.Features.Mediator.AuthMediator.Queries;
using MediatR;
using System.Security.Claims;

namespace CarBook.WebAPI.Endpoints.AuthEndpoints
{
    public static class AuthEndpoint
    {
        public static void AppAuthsEndpoint(this IEndpointRouteBuilder app)
        {
            var auths = app.MapGroup("/auth").WithTags("Auths");

            auths.MapPost("register", CreateUserAsync).AllowAnonymous();
            auths.MapPost("login", LoginUserAsync).AllowAnonymous();
            auths.MapPost("logout", LogoutAsync).RequireAuthorization();

        }

        private static async Task<IResult> CreateUserAsync(IMediator mediator, CreateRegisterCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        }

        private static async Task<IResult> LoginUserAsync(IMediator mediator, LoginQuery getLogin)
        {
            var result = await mediator.Send(getLogin);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        }

        private static async Task<IResult> LogoutAsync(IMediator mediator, ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Results.Unauthorized();

            var result = await mediator.Send(new LogoutCommand { UserId = userId });

            return Results.Ok(new { Message = result });
        }
    }
}
