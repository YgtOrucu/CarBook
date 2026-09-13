using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.CarCarPricingEndpoints
{
    public static class CarPricingEndpoint
    {
        public static void AppCarPricingEndpoint(this IEndpointRouteBuilder app)
        {
            var carPricing = app.MapGroup("/carPricing").WithTags("CarPricing");

            carPricing.MapGet("", GetCarPricingAsync).AllowAnonymous();
            carPricing.MapGet("/timeperiod", GetCarPricingWithTimePeriodAsync).AllowAnonymous();
            carPricing.MapGet("{carId}", GetCarPricingByCarIdAsync).AllowAnonymous();

            var adminCarPricing = carPricing.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminCarPricing.MapPost("", CreateCarPricingAsync);
            adminCarPricing.MapPut("", UpdateCarPricingAsync);
            adminCarPricing.MapDelete("{carId}", RemoveCarPricingAsync);
        }

        private static async Task<IResult> GetCarPricingAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetCarPricingQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }
        private static async Task<IResult> GetCarPricingByCarIdAsync(int carId, IMediator mediator)
        {
            var result = await mediator.Send(new GetCarPricingByIdQuery(carId));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> GetCarPricingWithTimePeriodAsync(IMediator mediator)
        {
            var result = await mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Results.Ok(result);
        }

        private static async Task<IResult> CreateCarPricingAsync(IMediator mediator, CreateCarPricingCommand command)
        {
            await mediator.Send(command);
            return Results.Ok("Fiyatlandırma başarıyla eklendi.");
        }

        private static async Task<IResult> UpdateCarPricingAsync(IMediator mediator, UpdateCarPricingCommand command)
        {
            await mediator.Send(command);
            return Results.Ok("Fiyatlandırma başarıyla güncellendi.");
        }

        private static async Task<IResult> RemoveCarPricingAsync(int carId, IMediator mediator)
        {
            await mediator.Send(new RemoveCarPricingCommand(carId));
            return Results.Ok("Fiyatlandırma başarıyla silindi.");
        }

    }
}
