using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;

namespace CarBook.WebAPI.Endpoints.FooterAddressEndpoints
{
    public static class FooterAddressEndpoint
    {
        public static void AppFooterAddressEndpoint(this IEndpointRouteBuilder app)
        {
            var footeraddress = app.MapGroup("/footerAddress").WithTags("FooterAddress");

            footeraddress.MapGet("", GetFooterAddressAsync).AllowAnonymous();
            footeraddress.MapGet("GetFooterAddressForPresantation", GetFooterAddressForPresantationAsync).AllowAnonymous();
            footeraddress.MapGet("{id}", GetFooterAddressByIdAsync).AllowAnonymous();
            var adminFooterAddress = footeraddress.MapGroup("").RequireAuthorization(policy => policy.RequireRole("Admin"));


            adminFooterAddress.MapPost("", CreateFooterAddressAsync);
            adminFooterAddress.MapPut("", UpdateFooterAddressAsync);
            adminFooterAddress.MapDelete("{id}", RemoveFooterAddressAsync);
        }


        private static async Task<IResult> CreateFooterAddressAsync(IMediator mediator, CreateFooterAddressCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> UpdateFooterAddressAsync(IMediator mediator, UpdateFooterAddressCommand command)
        {
            var response = await mediator.Send(command);
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetFooterAddressAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetFooterAddressQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetFooterAddressForPresantationAsync(IMediator mediator)
        {
            var response = await mediator.Send(new GetFooterAddressForPresantationPageQuery());
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> GetFooterAddressByIdAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new GetFooterAddressByIdQuery(id));
            return response != null ? Results.Ok(response) : Results.BadRequest(response);
        }

        private static async Task<IResult> RemoveFooterAddressAsync(int id, IMediator mediator)
        {
            var response = await mediator.Send(new DeleteFooterAddressCommand(id));
            return Results.Ok("The FooterAddress has been successfully deleted.");
        }
    }
}
