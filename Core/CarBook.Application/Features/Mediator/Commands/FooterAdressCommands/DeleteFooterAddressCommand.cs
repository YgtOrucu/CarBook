using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
    public record DeleteFooterAddressCommand(int Id) : IRequest<bool>;

}
