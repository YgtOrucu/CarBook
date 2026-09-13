using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.PricingEndpoints
{
    public static class PricingEndpoint
    {
        public static void AppPricingEndpoint(this IEndpointRouteBuilder app)
        {
            var pricing = app.MapGroup("/pricing").WithTags("Pricing");

            pricing.MapGet("", GetPricingAsync).AllowAnonymous();
            pricing.MapGet("{id}", GetPricingByIdAsync).AllowAnonymous();
            pricing.MapDelete("{id}", RemovePricingAsync).AllowAnonymous();

            var adminPricing = pricing.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminPricing.MapPost("", CreatePricingAsync);
            adminPricing.MapPut("", UpdatePricingAsync);
        }


        private static async Task<IResult> CreatePricingAsync(IMediator mediator, CreatePricingCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdatePricingAsync(IMediator mediator, UpdatePricingCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetPricingAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetPricingQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetPricingByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetPricingByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemovePricingAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new RemovePricingCommand(id));
            return Results.Ok(response);
        }
    }
}
