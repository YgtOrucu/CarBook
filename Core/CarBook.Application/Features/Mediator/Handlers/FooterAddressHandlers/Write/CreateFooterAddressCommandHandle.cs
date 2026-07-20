using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Write;

public class CreateFooterAddressCommandHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<CreateFooterAddressCommand, object>
{
    public async Task<object> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<FooterAddress>(request);

        await repository.CreateAsync(values);

        return new
        {
            success = true,
            messages = "The addition was succesful",
            data = values
        };
    }
}
