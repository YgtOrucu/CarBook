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

            socialMedia.MapPost(string.Empty, CreateSocialMediaAsync);
            socialMedia.MapPut(string.Empty, UpdateSocialMediaAsync);
            socialMedia.MapGet(string.Empty, GetSocialMediaAsync);
            socialMedia.MapGet("{id}", GetSocialMediaByIdAsync);
            socialMedia.MapDelete("{id}", RemoveSocialMediaAsync);
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
