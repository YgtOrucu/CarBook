using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.CarEndpoints
{
    public static class CarEndpoint
    {
        public static void AppCarEndpoint(this IEndpointRouteBuilder builder)
        {
            var cars = builder.MapGroup("/car").WithTags("Cars");

            cars.MapGet(string.Empty, GetCarAsync);
            cars.MapGet("{id}", GetCarByIdAsync);
            cars.MapGet("getBrand", GetCarWithBrandAsync);
            cars.MapGet("GetCarForPresantation", GetCarForPresantationPageAsync);
            cars.MapPost(string.Empty, CreateCarAsync);
            cars.MapPut(string.Empty, UpdateCarAsync);
            cars.MapDelete("{id}", RemoveCarAsync);
        }

        private static async Task<IResult> GetCarForPresantationPageAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetCarForPresantationPageQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetCarAsync(GetCarQueryHandle getCarQueryHandle)
        {
            var result = await getCarQueryHandle.Handle();
            return result != null ? Results.Ok(result) : Results.BadRequest("The Car listing process failed.");
        }

        private static async Task<IResult> GetCarByIdAsync(int id, GetCarByIdQueryHandle getCarByIdQueryHandle)
        {
            var result = await getCarByIdQueryHandle.Handle(new GetCarByIdQuery(id));
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        private static async Task<IResult> GetCarWithBrandAsync(GetCarWithBrandQueryHandle getCarWithBrandQueryHandle)
        {
            var result = await getCarWithBrandQueryHandle.Handle();
            return result != null ? Results.Ok(result) : Results.BadRequest("The Car listing process failed.");
        }

        private static async Task<IResult> CreateCarAsync(CreateCarCommandHandle createCarCommandHandle, CreateCarCommand command)
        {
            await createCarCommandHandle.Handle(command);
            return Results.Ok("The Car has been successfully created.");
        }

        private static async Task<IResult> UpdateCarAsync(UpdateCarCommandHandle updateCarCommandHandle, UpdateCarCommand command)
        {
            await updateCarCommandHandle.Handle(command);
            return Results.Ok("The Car has been successfully updated.");
        }

        private static async Task<IResult> RemoveCarAsync(int id, RemoveCarCommandHandle removeCarCommandHandle)
        {
            await removeCarCommandHandle.Handle(new RemoveCarCommand(id));
            return Results.Ok("The Car has been successfully deleted.");
        }
    }
}
