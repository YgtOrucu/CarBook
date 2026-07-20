using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write;

public class DeleteFooterAddressCommandHandle(IRepository<FooterAddress> repository)
    : IRequestHandler<DeleteFooterAddressCommand, bool>
{
    public async Task<bool> Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        repository.Delete(values);
        return true;
    }
}
