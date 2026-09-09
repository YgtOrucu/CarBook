using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using MediatR;

namespace CarBook.WebAPI.Endpoints.AuthEndpoints
{
    public static class AuthEndpoint
    {
        public static void AppAuthsEndpoint(this IEndpointRouteBuilder app)
        {
            var auths = app.MapGroup("/auth").WithTags("Auths");

            auths.MapPost("register", CreateUserAsync).AllowAnonymous();
            //auths.MapPost("login", LoginUserAsync).AllowAnonymous();
        }

        private static async Task<IResult> CreateUserAsync(IMediator mediator, CreateRegisterCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        }

        //private static async Task<IResult> LoginUserAsync(IMediator mediator, GetLoginQuery getLogin)
        //{
        //    var result = await mediator.Send(getLogin);
        //    return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        //}
    }
}
