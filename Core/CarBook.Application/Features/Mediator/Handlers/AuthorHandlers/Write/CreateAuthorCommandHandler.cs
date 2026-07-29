using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write;

public class CreateAuthorCommandHandler(IRepository<Author> repository, IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateAuthorCommand, object>
{
    public async Task<object> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<Author>(request);
        await repository.CreateAsync(values);
        await unitOfWork.SaveChangeAsync();
        return new
        {
            success = true,
            messages = "The addition was succesful",
            data = values
        };
    }
}
