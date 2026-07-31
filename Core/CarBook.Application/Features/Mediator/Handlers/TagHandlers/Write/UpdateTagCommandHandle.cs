using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers.Write;

public class UpdateTagCommandHandle(IRepository<Tag> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTagCommand, object>
{
    public async Task<object> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, values);
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The update was succesful",
            data = values
        };
    }
}
