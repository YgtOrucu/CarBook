using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.WriteOperations;

public class CreateSocialMediaCommandHandle(IRepository<SocialMedia> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSocialMediaCommand, object>
{
    public async Task<object> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(mapper.Map<SocialMedia>(request));
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The addition was succesful",
        };
    }
}
