using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.SocialMediaEndpoints
{
    public static class SocialMediaEndpoint
    {
        public static void AppSocialMediaEndpoint(this IEndpointRouteBuilder app)
        {
            var socialMedia = app.MapGroup("/socialMedia").WithTags("SocialMedia");

            socialMedia.MapGet("", GetSocialMediaAsync).AllowAnonymous();
            socialMedia.MapGet("{id}", GetSocialMediaByIdAsync).AllowAnonymous();

            var adminSocialMedia = socialMedia.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminSocialMedia.MapPost("", CreateSocialMediaAsync);
            adminSocialMedia.MapPut("", UpdateSocialMediaAsync);
            adminSocialMedia.MapDelete("{id}", RemoveSocialMediaAsync);
        }


        private static async Task<IResult> CreateSocialMediaAsync(IMediator mediator, CreateSocialMediaCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateSocialMediaAsync(IMediator mediator, UpdateSocialMediaCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetSocialMediaAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetSocialMediaQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetSocialMediaByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetSocialMediaByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveSocialMediaAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveSocialMediaCommand(id));
            return Results.Ok(response);
        }
    }
}
