using AutoMapper;
using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class CreateRegisterCommandHandle(UserManager<AppUser> userManager, IMapper mapper, IMediator mediator)
    : IRequestHandler<CreateRegisterCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        var mappedUser = mapper.Map<AppUser>(request);

        var result = await userManager.CreateAsync(mappedUser, request.Password);

        if (!result.Succeeded)
        {
            return BaseResult<object>.Failure(result.Errors);
        }

        var roleResult = await userManager.AddToRoleAsync(mappedUser, "User");

        if (!roleResult.Succeeded)
        {
            return BaseResult<object>.Failure(roleResult.Errors);
        }

        await mediator.Publish(new UserSendWelcomeEmailEvent(mappedUser.Email, mappedUser.Name + " " + mappedUser.Surname), cancellationToken);
        return BaseResult<object>.Success(true, "User created successfully");
    }
}