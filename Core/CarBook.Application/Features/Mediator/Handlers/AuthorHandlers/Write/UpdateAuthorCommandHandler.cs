using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write;

public class UpdateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAuthorCommand, object>
{
    public async Task<object> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);

        mapper.Map(request, values);
        repository.Update(values);
        await unitOfWork.SaveChangeAsync();
        return new
        {
            success = true,
            messages = "The update process was succesful.",
            data = values
        };
    }
}
