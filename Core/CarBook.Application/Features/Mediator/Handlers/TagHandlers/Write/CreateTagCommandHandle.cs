using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers.Write;

public class CreateTagCommandHandle(IRepository<Tag> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTagCommand, object>
{
    public async Task<object> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var value =  mapper.Map<Tag>(request);

        await repository.CreateAsync(value);
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The addition was succesful",
            data = value
        };
    }
}
