using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.ReservationEndpoints
{
    public static class ReservationEndpoint
    {
        public static void AppReservationEndpoint(this IEndpointRouteBuilder app)
        {
            var reservation = app.MapGroup("/reservation").WithTags("Reservation");

            reservation.MapGet("ReservationFormValues", GetReservationFormValues).AllowAnonymous();
            reservation.MapPost("", CreateReservationAsync).RequireAuthorization();
            reservation.MapGet("GetLoginUsersReservation/{email}", GetLoginUsersReservationAsync).RequireAuthorization();

            var adminReservation = reservation.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));

            adminReservation.MapGet("", GetListReservationAsync);
        }

        private static async Task<IResult> GetLoginUsersReservationAsync(string email, IMediator mediator)
        {
            var response = await mediator.Send(new GetLoginUsersReservationQuery(email));
            return response != null ? Results.Ok(response) : Results.NotFound("Kullanıcıya ait rezervasyon bulunamadı.");
        }

        private static async Task<IResult> CreateReservationAsync(IMediator mediator, CreateReservationCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetListReservationAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetReservationQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetReservationFormValues(IMediator mediator)
        {
            var response = await mediator.Send(new GetReservationFormValuesQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }
    }
}
