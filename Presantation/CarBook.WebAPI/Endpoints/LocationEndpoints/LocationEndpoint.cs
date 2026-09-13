using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.LocationEndpoints
{
    public static class LocationEndpoint
    {
        public static void AppLocationEndpoint(this IEndpointRouteBuilder app)
        {
            var location = app.MapGroup("/location").WithTags("Location");

            location.MapGet("", GetLocationAsync).AllowAnonymous();
            location.MapGet("{id}", GetLocationByIdAsync).AllowAnonymous();
            location.MapDelete("{id}", RemoveLocationAsync).AllowAnonymous();

            var adminLocation = location.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminLocation.MapPost("", CreateLocationAsync);
            adminLocation.MapPut("", UpdateLocationAsync);
        }


        private static async Task<IResult> CreateLocationAsync(IMediator mediator, CreateLocationCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateLocationAsync(IMediator mediator, UpdateLocationCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetLocationAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetLocationQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetLocationByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetLocationByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveLocationAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveLocationCommand(id));
            return Results.Ok(response);
        }
    }
}
