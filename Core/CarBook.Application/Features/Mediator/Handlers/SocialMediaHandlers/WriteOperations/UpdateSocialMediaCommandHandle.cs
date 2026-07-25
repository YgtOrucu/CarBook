using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.WriteOperations;

public class UpdateSocialMediaCommandHandle(IRepository<SocialMedia> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateSocialMediaCommand, object>
{
    public async Task<object> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
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
