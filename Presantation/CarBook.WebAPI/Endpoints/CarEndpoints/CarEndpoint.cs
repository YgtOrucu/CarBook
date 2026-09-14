using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;
using CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.CarEndpoints
{
    public static class CarEndpoint
    {
        public static void AppCarEndpoint(this IEndpointRouteBuilder builder)
        {
            var cars = builder.MapGroup("/car").WithTags("Cars");

            cars.MapGet("", GetCarAsync).AllowAnonymous();
            cars.MapGet("{id}", GetCarByIdAsync).AllowAnonymous();
            cars.MapGet("getBrand", GetCarWithBrandAsync).AllowAnonymous();
            cars.MapGet("GetCarForPresantation", GetCarForPresantationPageAsync).AllowAnonymous();
            cars.MapGet("GetCarLastest5ForPresantation", GetCarLastest5ForPresantationPageAsync).AllowAnonymous();
            cars.MapGet("CarDetails/{id}", GetCarDetailByCarIdAsync).AllowAnonymous();

            var adminCar = cars.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminCar.MapPost("", CreateCarAsync);
            adminCar.MapPut("", UpdateCarAsync);
            adminCar.MapDelete("{id}", RemoveCarAsync);
        }

        private static async Task<IResult> GetCarForPresantationPageAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetCarForPresantationPageQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }
        private static async Task<IResult> GetCarLastest5ForPresantationPageAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetCarLastest5ForPresantationPageQuery());
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

        private static async Task<IResult> GetCarDetailByCarIdAsync(int Id, IMediator mediator)
        {
            var result = await mediator.Send(new GetCarDetailByCarIdQuery(Id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
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
