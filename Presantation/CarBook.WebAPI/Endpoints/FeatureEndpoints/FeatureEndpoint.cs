using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.FeatureEndpoints
{
    public static class FeatureEndpoint
    {
        public static void AppFeatureEndpoint(this IEndpointRouteBuilder app)
        {
            var features = app.MapGroup("/feature").WithTags("Features");

            features.MapGet("", GetFeatureAsync).AllowAnonymous();
            features.MapGet("{id}", GetFeatureByIdAsync).AllowAnonymous();
            var adminFeature = features.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminFeature.MapPost("", CreateFeatureAsync);
            adminFeature.MapPut("", UpdateFeatureAsync);
            adminFeature.MapDelete("{id}", RemoveFeatureAsync);
        }

        private static async Task<IResult> GetFeatureAsync(IMediator mediator)
        {
            var result = await mediator.Send(new GetFeatureQuery());
            return result != null ? Results.Ok(result) : Results.BadRequest("The Feature listing process failed.");
        }

        private static async Task<IResult> GetFeatureByIdAsync(int id, IMediator mediator)
        {
            var result = await mediator.Send(new GetFeatureByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> CreateFeatureAsync(IMediator mediator, CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Results.Ok("Feature is succesfully added");
        }

        private static async Task<IResult> UpdateFeatureAsync(IMediator mediator, UpdateFeatureCommand command)
        {
            await mediator.Send(command);

            return Results.Ok("Feature başarıyla güncellendi.");
        }

        public static async Task<IResult> RemoveFeatureAsync(int id, IMediator mediator)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return Results.Ok("Feature başarıyla silinde.");
        }
    }
}
