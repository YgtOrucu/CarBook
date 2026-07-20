using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write;

public class UpdateFooterAddressCommandHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<UpdateFooterAddressCommand, object>
{
    public async Task<object> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);

        mapper.Map(request,values);
        repository.Update(values);
        return new
        {
            success = true,
            messages = "The update process was succesful.",
            data = values
        };
    }
}
