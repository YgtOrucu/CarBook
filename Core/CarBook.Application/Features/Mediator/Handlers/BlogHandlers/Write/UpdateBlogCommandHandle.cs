using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write;

public class UpdateBlogCommandHandle(IRepository<Blog> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBlogCommand, object>
{
    public async Task<object> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
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
