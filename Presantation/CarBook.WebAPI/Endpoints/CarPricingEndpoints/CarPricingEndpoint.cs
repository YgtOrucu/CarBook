using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.CarCarPricingEndpoints
{
    public static class CarPricingEndpoint
    {
        public static void AppCarPricingEndpoint(this IEndpointRouteBuilder app)
        {
            var carPricing = app.MapGroup("/carPricing").WithTags("CarPricing");

            //carPricing.MapPost(string.Empty, CreateCarPricingAsync);
            //carPricing.MapPut(string.Empty, UpdateCarPricingAsync);
            carPricing.MapGet(string.Empty, GetCarPricingAsync);
            //carPricing.MapGet("{id}", GetCarPricingByIdAsync);
            //carPricing.MapDelete("{id}", RemoveCarPricingAsync);
        }


        //private static async Task<IResult> CreateCarPricingAsync(IMediator mediator, CreateCarPricingCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> UpdateCarPricingAsync(IMediator mediator, UpdateCarPricingCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        private static async Task<IResult> GetCarPricingAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetCarPricingQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        //private static async Task<IResult> GetCarPricingByIdAsync(int id, IMediator mediator)
        //{
        //    var response = await mediator.Send(new GetCarPricingByIdQuery(id));
        //    return response != null ? Results.Ok(response) : Results.BadRequest(response);
        //}

        //private static async Task<IResult> RemoveCarPricingAsync(int id, IMediator mediator)
        //{
        //    var response = await mediator.Send(new RemoveCarPricingCommand(id));
        //    return Results.Ok(response);
        //}
    }
}
