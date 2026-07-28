using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.ServicesEndpoints
{
    public static class ServicesEndpoint
    {
        public static void AppServicesEndpoint(this IEndpointRouteBuilder app)
        {
            var services = app.MapGroup("/services").WithTags("Services");

            services.MapPost(string.Empty, CreateServicesAsync);
            services.MapPut(string.Empty, UpdateServicesAsync);
            services.MapGet(string.Empty, GetServicesAsync);
            services.MapGet("Lastest5Services", GetServicesLastest5Async);
            services.MapGet("{id}", GetServicesByIdAsync);
            services.MapDelete("{id}", RemoveServicesAsync);
        }


        private static async Task<IResult> CreateServicesAsync(IMediator mediator, CreateServicesCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateServicesAsync(IMediator mediator, UpdateServicesCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetServicesAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetServicesQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetServicesLastest5Async(IMediator mediator)
        {
            var response = await mediator.Send(new GetServicesLastest5Query());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetServicesByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetServicesByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveServicesAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemoveServicesCommand(id));
            return Results.Ok(response);
        }
    }
}
