using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write;

public class CreateBlogCommandHandle(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBlogCommand, object>
{
    public async Task<object> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<Blog>(request);
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
